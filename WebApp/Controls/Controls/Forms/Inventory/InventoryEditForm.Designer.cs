namespace Ivs.Controls.Forms.Inventory
{
    partial class InventoryEditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryEditForm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            this.btnPrintSheet = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnInventory = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportXls = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportXlsx = new DevExpress.XtraBars.BarButtonItem();
            this.btnExport = new DevExpress.XtraBars.BarButtonItem();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Appearance.BorderColor = ((System.Drawing.Color)(resources.GetObject("lblErrorMessage.Appearance.BorderColor")));
            this.lblErrorMessage.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblErrorMessage.Appearance.Font")));
            this.lblErrorMessage.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblErrorMessage.Appearance.ForeColor")));
            resources.ApplyResources(this.lblErrorMessage, "lblErrorMessage");
            // 
            // panelMain
            // 
            resources.ApplyResources(this.panelMain, "panelMain");
            // 
            // btnPrintSheet
            // 
            resources.ApplyResources(this.btnPrintSheet, "btnPrintSheet");
            this.btnPrintSheet.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrintSheet.Glyph")));
            this.btnPrintSheet.Id = 10;
            this.btnPrintSheet.Name = "btnPrintSheet";
            this.btnPrintSheet.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCancel.Glyph")));
            this.btnCancel.Id = 9;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnInventory
            // 
            resources.ApplyResources(this.btnInventory, "btnInventory");
            this.btnInventory.Glyph = ((System.Drawing.Image)(resources.GetObject("btnInventory.Glyph")));
            this.btnInventory.Id = 8;
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnExportXls
            // 
            resources.ApplyResources(this.btnExportXls, "btnExportXls");
            this.btnExportXls.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportXls.Glyph")));
            this.btnExportXls.Id = 9;
            this.btnExportXls.Name = "btnExportXls";
            this.btnExportXls.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnExport.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            // 
            // btnExportXlsx
            // 
            resources.ApplyResources(this.btnExportXlsx, "btnExportXlsx");
            this.btnExportXlsx.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportXlsx.Glyph")));
            this.btnExportXlsx.Id = 10;
            this.btnExportXlsx.Name = "btnExportXlsx";
            this.btnExportXlsx.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExport.Glyph")));
            this.btnExport.Id = 8;
            this.btnExport.Name = "btnExport";
            this.btnExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            resources.ApplyResources(toolTipTitleItem1, "toolTipTitleItem1");
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnExport.SuperTip = superToolTip1;
            // 
            // InventoryEditForm
            // 
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("InventoryEditForm.Appearance.Font")));
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "InventoryEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = true;
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected DevExpress.XtraBars.BarButtonItem btnPrintSheet;
        protected DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarButtonItem btnInventory;
        private DevExpress.XtraBars.BarButtonItem btnExportXls;
        private DevExpress.XtraBars.BarButtonItem btnExportXlsx;
        private DevExpress.XtraBars.BarButtonItem btnExport;
       
    }
}