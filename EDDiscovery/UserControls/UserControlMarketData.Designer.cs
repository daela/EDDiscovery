﻿/*
 * Copyright © 2016 - 2017 EDDiscovery development team
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
namespace EDDiscovery.UserControls
{
    partial class UserControlMarketData
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataViewScrollerPanel = new ExtendedControls.DataViewScrollerPanel();
            this.dataGridViewMarketData = new System.Windows.Forms.DataGridView();
            this.contextMenuStripLedger = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemGotoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vScrollBarCustomMC = new ExtendedControls.VScrollBarCustom();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.labelTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CargoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DemandCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GalAvgCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfitToCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfitFromCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataViewScrollerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMarketData)).BeginInit();
            this.contextMenuStripLedger.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataViewScrollerPanel
            // 
            this.dataViewScrollerPanel.Controls.Add(this.dataGridViewMarketData);
            this.dataViewScrollerPanel.Controls.Add(this.vScrollBarCustomMC);
            this.dataViewScrollerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewScrollerPanel.InternalMargin = new System.Windows.Forms.Padding(0);
            this.dataViewScrollerPanel.Location = new System.Drawing.Point(0, 32);
            this.dataViewScrollerPanel.Name = "dataViewScrollerPanel";
            this.dataViewScrollerPanel.ScrollBarWidth = 20;
            this.dataViewScrollerPanel.Size = new System.Drawing.Size(800, 540);
            this.dataViewScrollerPanel.TabIndex = 0;
            this.dataViewScrollerPanel.VerticalScrollBarDockRight = true;
            // 
            // dataGridViewMarketData
            // 
            this.dataGridViewMarketData.AllowUserToAddRows = false;
            this.dataGridViewMarketData.AllowUserToDeleteRows = false;
            this.dataGridViewMarketData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMarketData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMarketData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCol,
            this.SellCol,
            this.BuyCol,
            this.CargoCol,
            this.DemandCol,
            this.SupplyCol,
            this.GalAvgCol,
            this.ProfitToCol,
            this.ProfitFromCol});
            this.dataGridViewMarketData.ContextMenuStrip = this.contextMenuStripLedger;
            this.dataGridViewMarketData.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMarketData.Name = "dataGridViewMarketData";
            this.dataGridViewMarketData.RowHeadersVisible = false;
            this.dataGridViewMarketData.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewMarketData.Size = new System.Drawing.Size(780, 540);
            this.dataGridViewMarketData.TabIndex = 1;
            this.dataGridViewMarketData.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridViewLedger_SortCompare);
            // 
            // contextMenuStripLedger
            // 
            this.contextMenuStripLedger.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemGotoItem});
            this.contextMenuStripLedger.Name = "contextMenuStripLedger";
            this.contextMenuStripLedger.Size = new System.Drawing.Size(207, 26);
            // 
            // toolStripMenuItemGotoItem
            // 
            this.toolStripMenuItemGotoItem.Name = "toolStripMenuItemGotoItem";
            this.toolStripMenuItemGotoItem.Size = new System.Drawing.Size(206, 22);
            this.toolStripMenuItemGotoItem.Text = "Go to entry on travel grid";
            this.toolStripMenuItemGotoItem.Click += new System.EventHandler(this.toolStripMenuItemGotoItem_Click);
            // 
            // vScrollBarCustomMC
            // 
            this.vScrollBarCustomMC.ArrowBorderColor = System.Drawing.Color.LightBlue;
            this.vScrollBarCustomMC.ArrowButtonColor = System.Drawing.Color.LightGray;
            this.vScrollBarCustomMC.ArrowColorScaling = 0.5F;
            this.vScrollBarCustomMC.ArrowDownDrawAngle = 270F;
            this.vScrollBarCustomMC.ArrowUpDrawAngle = 90F;
            this.vScrollBarCustomMC.BorderColor = System.Drawing.Color.White;
            this.vScrollBarCustomMC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.vScrollBarCustomMC.HideScrollBar = false;
            this.vScrollBarCustomMC.LargeChange = 0;
            this.vScrollBarCustomMC.Location = new System.Drawing.Point(780, 21);
            this.vScrollBarCustomMC.Maximum = -1;
            this.vScrollBarCustomMC.Minimum = 0;
            this.vScrollBarCustomMC.MouseOverButtonColor = System.Drawing.Color.Green;
            this.vScrollBarCustomMC.MousePressedButtonColor = System.Drawing.Color.Red;
            this.vScrollBarCustomMC.Name = "vScrollBarCustomMC";
            this.vScrollBarCustomMC.Size = new System.Drawing.Size(20, 519);
            this.vScrollBarCustomMC.SliderColor = System.Drawing.Color.DarkGray;
            this.vScrollBarCustomMC.SmallChange = 1;
            this.vScrollBarCustomMC.TabIndex = 0;
            this.vScrollBarCustomMC.Text = "vScrollBarCustom1";
            this.vScrollBarCustomMC.ThumbBorderColor = System.Drawing.Color.Yellow;
            this.vScrollBarCustomMC.ThumbButtonColor = System.Drawing.Color.DarkBlue;
            this.vScrollBarCustomMC.ThumbColorScaling = 0.5F;
            this.vScrollBarCustomMC.ThumbDrawAngle = 0F;
            this.vScrollBarCustomMC.Value = -1;
            this.vScrollBarCustomMC.ValueLimited = -1;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.labelTime);
            this.panelButtons.Controls.Add(this.label1);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelButtons.Location = new System.Drawing.Point(0, 0);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(800, 32);
            this.panelButtons.TabIndex = 2;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(64, 7);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(30, 13);
            this.labelTime.TabIndex = 26;
            this.labelTime.Text = "Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Search";
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // NameCol
            // 
            this.NameCol.HeaderText = "Name";
            this.NameCol.MinimumWidth = 100;
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            // 
            // SellCol
            // 
            this.SellCol.FillWeight = 30F;
            this.SellCol.HeaderText = "Sell";
            this.SellCol.MinimumWidth = 50;
            this.SellCol.Name = "SellCol";
            this.SellCol.ReadOnly = true;
            // 
            // BuyCol
            // 
            this.BuyCol.FillWeight = 30F;
            this.BuyCol.HeaderText = "Buy";
            this.BuyCol.MinimumWidth = 50;
            this.BuyCol.Name = "BuyCol";
            this.BuyCol.ReadOnly = true;
            // 
            // CargoCol
            // 
            this.CargoCol.FillWeight = 30F;
            this.CargoCol.HeaderText = "Cargo";
            this.CargoCol.MinimumWidth = 50;
            this.CargoCol.Name = "CargoCol";
            this.CargoCol.ReadOnly = true;
            // 
            // DemandCol
            // 
            this.DemandCol.FillWeight = 30F;
            this.DemandCol.HeaderText = "Demand";
            this.DemandCol.MinimumWidth = 50;
            this.DemandCol.Name = "DemandCol";
            this.DemandCol.ReadOnly = true;
            // 
            // SupplyCol
            // 
            this.SupplyCol.FillWeight = 30F;
            this.SupplyCol.HeaderText = "Supply";
            this.SupplyCol.MinimumWidth = 50;
            this.SupplyCol.Name = "SupplyCol";
            this.SupplyCol.ReadOnly = true;
            // 
            // GalAvgCol
            // 
            this.GalAvgCol.FillWeight = 30F;
            this.GalAvgCol.HeaderText = "Galactic Avg";
            this.GalAvgCol.MinimumWidth = 50;
            this.GalAvgCol.Name = "GalAvgCol";
            this.GalAvgCol.ReadOnly = true;
            // 
            // ProfitToCol
            // 
            this.ProfitToCol.FillWeight = 30F;
            this.ProfitToCol.HeaderText = "ProfitTo";
            this.ProfitToCol.MinimumWidth = 50;
            this.ProfitToCol.Name = "ProfitToCol";
            this.ProfitToCol.ReadOnly = true;
            // 
            // ProfitFromCol
            // 
            this.ProfitFromCol.FillWeight = 30F;
            this.ProfitFromCol.HeaderText = "Profit From";
            this.ProfitFromCol.MinimumWidth = 50;
            this.ProfitFromCol.Name = "ProfitFromCol";
            this.ProfitFromCol.ReadOnly = true;
            // 
            // UserControlMarketData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataViewScrollerPanel);
            this.Controls.Add(this.panelButtons);
            this.Name = "UserControlMarketData";
            this.Size = new System.Drawing.Size(800, 572);
            this.dataViewScrollerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMarketData)).EndInit();
            this.contextMenuStripLedger.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ExtendedControls.DataViewScrollerPanel dataViewScrollerPanel;
        private System.Windows.Forms.DataGridView dataGridViewMarketData;
        private ExtendedControls.VScrollBarCustom vScrollBarCustomMC;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLedger;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGotoItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CargoCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DemandCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn GalAvgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfitToCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfitFromCol;
    }
}