﻿/*
 * Copyright © 2017 EDDiscovery development team
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this
 * file except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software distributed under
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
 * ANY KIND, either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 * 
 * EDDiscovery is not affiliated with Frontier Developments plc.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseUtils;
using Conditions;

namespace EDDiscovery.Versions
{
    public class VersioningManager
    {
        public enum ItemState
        {
            None,
            LocalOnly,
            EDOutOfDate,
            NotPresent,
            UpToDate,
            OutOfDate,
        }

        public class DownloadItem
        {
            public bool HasDownloadedCopy { get { return downloadedfilename != null;  } }
            public string LongDownloadedDescription { get { return downloadedvars != null && downloadedvars.Exists("LongDescription") ? downloadedvars["LongDescription"] : ""; } }

            public string downloadedpath;
            public string downloadedfilename;
            public int[] downloadedversion;
            public ConditionVariables downloadedvars;

            public bool HasLocalCopy { get { return localfound; } }
            public string LongLocalDescription { get { return localvars != null && localvars.Exists("LongDescription") ? localvars["LongDescription"] : ""; } }
            public string ShortLocalDescription { get { return localvars != null && localvars.Exists("ShortDescription") ? localvars["ShortDescription"] : ""; } }

            public bool localfound;             // if scanned locally
            public string localfilename;        // always set
            public string localpath;            // always set
            public int[] localversion;          // may be null if file does not have version
            public bool localmodified;          // if local file exists, sha comparison
            public ConditionVariables localvars;    //  null, or set if local has variables
            public bool? localenable;       // null, or set if local has variables and a Enable flag

            public ItemState state;

            public string itemname;
            public string itemtype;
        };

        public List<DownloadItem> downloaditems = new List<DownloadItem>();

        public VersioningManager()
        {
        }

        public void ReadLocalFiles(string appfolder, string subfolder, string filename , string itemtype)       // DONE FIRST
        {
            string installfolder = System.IO.Path.Combine(appfolder, subfolder);
            if (!System.IO.Directory.Exists(installfolder))
                System.IO.Directory.CreateDirectory(installfolder);

            FileInfo[] allFiles = Directory.EnumerateFiles(installfolder, filename, SearchOption.TopDirectoryOnly).Select(f => new FileInfo(f)).OrderBy(p => p.Name).ToArray();

            foreach (FileInfo f in allFiles)
            {
                try
                {
                    DownloadItem it = new DownloadItem();

                    it.localfound = true;

                    it.itemname = Path.GetFileNameWithoutExtension(f.FullName);
                    it.itemtype = itemtype;

                    it.localfilename = f.FullName;
                    it.localpath = installfolder;

                    it.state = ItemState.LocalOnly;
                    it.localvars = ReadVarsFromFile(f.FullName , out it.localenable);

                    if (it.localvars != null)       // always reads some vars as long as file is there..
                    {
                        if (it.localvars.Exists("Version"))     
                        {
                            it.localversion = it.localvars["Version"].VersionFromString();
                            it.localmodified = !WriteOrCheckSHAFile(it, it.localvars, appfolder, false);
                        }
                        else
                        {
                            it.localversion = new int[] { 0, 0, 0, 0 };
                            it.localmodified = true;
                        }
                    }

                    downloaditems.Add(it);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Exception read local files");
                }
            }
        }

        public void ReadInstallFiles(string folder, string appfolder, string filename, int[] edversion , string itemtype)
        {
            FileInfo[] allFiles = Directory.EnumerateFiles(folder, filename, SearchOption.TopDirectoryOnly).Select(f => new FileInfo(f)).OrderBy(p => p.Name).ToArray();

            foreach (FileInfo f in allFiles)
            {
                try
                {
                    bool? enabled;   // don't care about this in remote files
                    ConditionVariables cv = ReadVarsFromFile(f.FullName,out enabled);

                    if (cv != null)
                    {
                        int[] version;

                        if (cv.Exists("LongDescription") && cv.Exists("ShortDescription") &&
                            cv.Exists("Version") && cv.Exists("Location") &&
                            cv.Exists("MinEDVersion") &&
                            (version = cv["Version"].VersionFromString()) != null
                            )
                        {
                            string installfolder = System.IO.Path.Combine(appfolder, cv["Location"]);
                            string localfilename = System.IO.Path.Combine(installfolder, Path.GetFileName(f.FullName));

                            DownloadItem it = downloaditems.Find(x => x.localfilename.Equals(localfilename, StringComparison.InvariantCultureIgnoreCase));

                            if (it != null)
                            {
                                it.downloadedpath = folder;
                                it.downloadedfilename = f.FullName;
                                it.downloadedvars = cv;
                                it.downloadedversion = version;

                                it.state = (it.downloadedversion.CompareVersion(it.localversion) > 0) ? ItemState.OutOfDate : ItemState.UpToDate;
                            }
                            else
                            {
                                it = new DownloadItem()
                                {
                                    itemname = Path.GetFileNameWithoutExtension(f.FullName),
                                    itemtype = itemtype,

                                    downloadedpath = folder,
                                    downloadedfilename = f.FullName,
                                    downloadedversion = version,
                                    downloadedvars = cv,

                                    localfilename = localfilename,          // set these so it knows where to install..
                                    localpath = installfolder,

                                    state = ItemState.NotPresent,
                                };

                                downloaditems.Add(it);
                            }

                            int[] minedversion = cv["MinEDVersion"].VersionFromString();

                            if (minedversion.CompareVersion(edversion) > 0)
                                it.state = ItemState.EDOutOfDate;

                        }
                    }
                }
                catch { }
            }
        }

        private ConditionVariables ReadVarsFromFile(string file, out bool? enable)
        {
            return ActionLanguage.ActionFile.ReadVarsAndEnableFromFile(file, out enable);      // note other files share the actionfile Enabled and INSTALL format.. not the other bits
        }

        static public bool SetEnableFlag(DownloadItem item, bool enable, string appfolder)      // false if could not change the flag
        {
            if (File.Exists(item.localfilename))    // if its there..
            { 
                if (ActionLanguage.ActionFile.SetEnableFlag(item.localfilename, enable))     // if enable flag was changed..
                {
                    if (!item.localmodified)      // if was not local modified, lets set the SHA so it does not appear local modified just because of the enable
                        WriteOrCheckSHAFile(item, item.localvars, appfolder, true);

                    return true;
                }
            }

            return false;
        }

        public bool InstallFiles(DownloadItem item, string appfolder)
        {
            try
            {
                foreach (string key in item.downloadedvars.NameEnumuerable)  // these first, they are not the controller files
                {
                    if (key.StartsWith("OtherFile"))
                    {
                        string[] parts = item.downloadedvars[key].Split(';');
                        string folder = Path.Combine(appfolder, parts[1]);
                        if (!Directory.Exists(folder))      // ensure the folder exists
                            Directory.CreateDirectory(folder);
                        string outfile = Path.Combine(folder, parts[0] );
                        string source = Path.Combine(item.downloadedpath, parts[0]);
                        File.Copy(source, outfile, true);
                    }

                    if (key.StartsWith("DisableOther"))
                    {
                        DownloadItem other = downloaditems.Find(x => x.itemname.Equals(item.downloadedvars[key]));

                        if (other != null && other.localfilename != null )
                            SetEnableFlag(other, false, appfolder); // don't worry if it fails..
                    }
                }

                File.Copy(item.downloadedfilename, item.localfilename, true);

                WriteOrCheckSHAFile(item, item.downloadedvars, appfolder, true);

                return true;
            }
            catch
            {
                return false;
            }
        }

        static public bool DeleteInstall(DownloadItem item, string appfolder)
        {
            try
            {
                foreach (string key in item.localvars.NameEnumuerable)  // these first, they are not the controller files
                {
                    if (key.StartsWith("OtherFile"))
                    {
                        string[] parts = item.localvars[key].Split(';');
                        string o = Path.Combine(new string[] { appfolder, parts[1], parts[0] });
                        File.Delete(o);
                    }
                }

                File.Delete(item.localfilename);
                string shafile = Path.Combine(item.localpath, item.itemname + ".sha");
                File.Delete(shafile);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // true for write, for read its true if the same..

        static bool WriteOrCheckSHAFile(DownloadItem it, ConditionVariables vars, string appfolder, bool write)
        {
            try
            {
                List<string> filelist = new List<string>() { it.localfilename };

                foreach (string key in vars.NameEnumuerable)  // these first, they are not the controller files
                {
                    if (key.StartsWith("OtherFile"))
                    {
                        string[] parts = vars[key].Split(';');
                        string o = Path.Combine(new string[] { appfolder, parts[1], parts[0] });
                        filelist.Add(o);
                    }
                }

                string shacurrent = GitHubClass.CalcSha1(filelist.ToArray());

                string shafile = Path.Combine(it.localpath, it.itemname + ".sha");

                if (write)
                {
                    using (StreamWriter sr = new StreamWriter(shafile))         // read directly from file..
                    {
                        sr.Write(shacurrent);
                    }

                    return true;
                }
                else
                {
                    if (File.Exists(shafile))       // if there is no SHA file, its local, prob under dev, so its false.  SHA is only written by install
                    {
                        using (StreamReader sr = new StreamReader(shafile))         // read directly from file..
                        {
                            string shastored = sr.ReadToEnd();
                            sr.Close();

                            if (shastored.Equals(shacurrent))
                                return true;
                        }
                    }
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("BUG BUG");
            }

            return false;
        }

        class SortIt : IComparer<DownloadItem>
        {
            public int Compare(DownloadItem our, DownloadItem other)
            {
                return our.itemname.CompareTo(other.itemname);
            }
        }

        public void Sort()
        {
            downloaditems.Sort(new SortIt());
        }

    }
}
