
using Ivs.Controls.CustomControls.WinForm;

namespace Ivs.Controls.Forms
{
    partial class MasterEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterEditForm));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            this.barManager1 = new Ivs.Controls.CustomControls.WinForm.IvsBarManager();
            this.bar2 = new Ivs.Controls.CustomControls.WinForm.IvsBar();
            this.lblPath = new Ivs.Controls.CustomControls.WinForm.IvsBarStaticItem();
            this.bar3 = new Ivs.Controls.CustomControls.WinForm.IvsBar();
            this.btnSaveAndClose = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnPrevious = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnSaveAndNext = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnClear = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnClose = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.barDockControlTop = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.barDockControlBottom = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.barDockControlLeft = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.barDockControlRight = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.lblErrorMessage = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.panel2 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.panelMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblPath,
            this.btnSaveAndClose,
            this.btnClear,
            this.btnClose,
            this.btnSaveAndNext,
            this.btnPrevious});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblPath)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar2, "bar2");
            // 
            // lblPath
            // 
            resources.ApplyResources(this.lblPath, "lblPath");
            this.lblPath.Id = 0;
            this.lblPath.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("lblPath.ItemAppearance.Normal.Font")));
            this.lblPath.ItemAppearance.Normal.Options.UseFont = true;
            this.lblPath.Name = "lblPath";
            this.lblPath.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveAndClose),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrevious),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveAndNext),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar3, "bar3");
            // 
            // btnSaveAndClose
            // 
            resources.ApplyResources(this.btnSaveAndClose, "btnSaveAndClose");
            this.btnSaveAndClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.Glyph")));
            this.btnSaveAndClose.Id = 2;
            this.btnSaveAndClose.ImageIndex = 0;
            this.btnSaveAndClose.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnSaveAndClose.ItemAppearance.Normal.Font")));
            this.btnSaveAndClose.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            resources.ApplyResources(toolTipTitleItem1, "toolTipTitleItem1");
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnSaveAndClose.SuperTip = superToolTip1;
            // 
            // btnPrevious
            // 
            resources.ApplyResources(this.btnPrevious, "btnPrevious");
            this.btnPrevious.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Glyph")));
            this.btnPrevious.Id = 7;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            resources.ApplyResources(toolTipTitleItem2, "toolTipTitleItem2");
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnPrevious.SuperTip = superToolTip2;
            // 
            // btnSaveAndNext
            // 
            resources.ApplyResources(this.btnSaveAndNext, "btnSaveAndNext");
            this.btnSaveAndNext.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAndNext.Glyph")));
            this.btnSaveAndNext.Id = 5;
            this.btnSaveAndNext.Name = "btnSaveAndNext";
            this.btnSaveAndNext.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnClear
            // 
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClear.Glyph")));
            this.btnClear.Id = 3;
            this.btnClear.ImageIndex = 0;
            this.btnClear.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnClear.ItemAppearance.Normal.Font")));
            this.btnClear.ItemAppearance.Normal.Options.UseFont = true;
            this.btnClear.Name = "btnClear";
            this.btnClear.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 4;
            this.btnClose.ImageIndex = 0;
            this.btnClose.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnClose.ItemAppearance.Normal.Font")));
            this.btnClose.ItemAppearance.Normal.Options.UseFont = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            resources.ApplyResources(toolTipTitleItem3, "toolTipTitleItem3");
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnClose.SuperTip = superToolTip3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Appearance.BorderColor = ((System.Drawing.Color)(resources.GetObject("lblErrorMessage.Appearance.BorderColor")));
            this.lblErrorMessage.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblErrorMessage.Appearance.Font")));
            this.lblErrorMessage.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblErrorMessage.Appearance.ForeColor")));
            resources.ApplyResources(this.lblErrorMessage, "lblErrorMessage");
            this.lblErrorMessage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblErrorMessage.Name = "lblErrorMessage";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panel2);
            this.panelMain.Controls.Add(this.lblErrorMessage);
            resources.ApplyResources(this.panelMain, "panelMain");
            this.panelMain.Name = "panelMain";
            // 
            // MasterEditForm
            // 
            this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("MasterEditForm.Appearance.Font")));
            this.Appearance.Options.UseFont = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MasterEditForm";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected IvsBarStaticItem lblPath;
        protected IvsBar bar3;
        protected IvsBarButtonItem btnSaveAndClose;
        protected IvsBarButtonItem btnClear;
        protected IvsBarButtonItem btnClose;
        protected IvsBarDockControl barDockControlTop;
        protected IvsBarDockControl barDockControlBottom;
        protected IvsBarDockControl barDockControlLeft;
        protected IvsBarDockControl barDockControlRight;
        protected IvsBarButtonItem btnSaveAndNext;
        protected IvsBarManager barManager1;
        protected IvsBar bar2;
        protected IvsBarButtonItem btnPrevious;
        protected IvsPanel panel2;
        protected IvsLabelControl lblErrorMessage;
        public System.Windows.Forms.Panel panelMain;
    }
}