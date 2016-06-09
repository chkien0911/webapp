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
            this.btnPrintSheet = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.btnInventory = new DevExpress.XtraBars.BarButtonItem();
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
       
    }
}