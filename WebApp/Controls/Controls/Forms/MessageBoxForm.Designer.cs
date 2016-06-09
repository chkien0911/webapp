namespace Ivs.Controls.Forms
{
    partial class MessageBoxs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxs));
            this.panel1 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.lbl_JP = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection();
            this.lbl_VN = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lbl_EN = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.dgcMain = new Ivs.Controls.CustomControls.WinForm.IvsGridControl();
            this.gridView2 = new Ivs.Controls.CustomControls.WinForm.IvsGridView();
            this.colErrorType = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.colTypeImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.resIcon = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.colMessageText = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.memoEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.panel2 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.btnCancel = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.btnOKClose = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.btnNo = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.btnExport = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.btnYes = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.tableLayoutPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsTableLayoutPanel();
            this.ivsPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.itemLanguage = new Ivs.Controls.CustomControls.WinForm.IvsBarEditItem();
            this.ivsLookUpEdit11 = new Ivs.Controls.CustomControls.WinForm.IvsLookUpEdit1();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ivsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ivsLookUpEdit11.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.lbl_JP);
            this.panel1.Controls.Add(this.lbl_VN);
            this.panel1.Controls.Add(this.lbl_EN);
            this.panel1.Name = "panel1";
            // 
            // lbl_JP
            // 
            resources.ApplyResources(this.lbl_JP, "lbl_JP");
            this.lbl_JP.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lbl_JP.Appearance.BackColor")));
            this.lbl_JP.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbl_JP.Appearance.DisabledImage")));
            this.lbl_JP.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbl_JP.Appearance.GradientMode")));
            this.lbl_JP.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbl_JP.Appearance.HoverImage")));
            this.lbl_JP.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbl_JP.Appearance.Image")));
            this.lbl_JP.Appearance.ImageIndex = 3;
            this.lbl_JP.Appearance.ImageList = this.imageCollection1;
            this.lbl_JP.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbl_JP.Appearance.PressedImage")));
            this.lbl_JP.HtmlImages = this.imageCollection1;
            this.lbl_JP.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.lbl_JP.Name = "lbl_JP";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "vn.png");
            this.imageCollection1.Images.SetKeyName(1, "gb.png");
            this.imageCollection1.Images.SetKeyName(2, "jp.png");
            this.imageCollection1.Images.SetKeyName(3, "Japan-Flag 16.png");
            // 
            // lbl_VN
            // 
            resources.ApplyResources(this.lbl_VN, "lbl_VN");
            this.lbl_VN.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbl_VN.Appearance.DisabledImage")));
            this.lbl_VN.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbl_VN.Appearance.GradientMode")));
            this.lbl_VN.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbl_VN.Appearance.HoverImage")));
            this.lbl_VN.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbl_VN.Appearance.Image")));
            this.lbl_VN.Appearance.ImageIndex = 0;
            this.lbl_VN.Appearance.ImageList = this.imageCollection1;
            this.lbl_VN.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbl_VN.Appearance.PressedImage")));
            this.lbl_VN.HtmlImages = this.imageCollection1;
            this.lbl_VN.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.lbl_VN.Name = "lbl_VN";
            // 
            // lbl_EN
            // 
            resources.ApplyResources(this.lbl_EN, "lbl_EN");
            this.lbl_EN.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lbl_EN.Appearance.DisabledImage")));
            this.lbl_EN.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lbl_EN.Appearance.GradientMode")));
            this.lbl_EN.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lbl_EN.Appearance.HoverImage")));
            this.lbl_EN.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lbl_EN.Appearance.Image")));
            this.lbl_EN.Appearance.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_EN.Appearance.ImageIndex = 1;
            this.lbl_EN.Appearance.ImageList = this.imageCollection1;
            this.lbl_EN.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lbl_EN.Appearance.PressedImage")));
            this.lbl_EN.HtmlImages = this.imageCollection1;
            this.lbl_EN.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.lbl_EN.Name = "lbl_EN";
            // 
            // dgcMain
            // 
            resources.ApplyResources(this.dgcMain, "dgcMain");
            this.dgcMain.EmbeddedNavigator.AccessibleDescription = resources.GetString("dgcMain.EmbeddedNavigator.AccessibleDescription");
            this.dgcMain.EmbeddedNavigator.AccessibleName = resources.GetString("dgcMain.EmbeddedNavigator.AccessibleName");
            this.dgcMain.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("dgcMain.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.dgcMain.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("dgcMain.EmbeddedNavigator.Anchor")));
            this.dgcMain.EmbeddedNavigator.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dgcMain.EmbeddedNavigator.BackgroundImage")));
            this.dgcMain.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("dgcMain.EmbeddedNavigator.BackgroundImageLayout")));
            this.dgcMain.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("dgcMain.EmbeddedNavigator.ImeMode")));
            this.dgcMain.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("dgcMain.EmbeddedNavigator.TextLocation")));
            this.dgcMain.EmbeddedNavigator.ToolTip = resources.GetString("dgcMain.EmbeddedNavigator.ToolTip");
            this.dgcMain.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("dgcMain.EmbeddedNavigator.ToolTipIconType")));
            this.dgcMain.EmbeddedNavigator.ToolTipTitle = resources.GetString("dgcMain.EmbeddedNavigator.ToolTipTitle");
            this.dgcMain.MainView = this.gridView2;
            this.dgcMain.MoveNextRowWhenLastCellFocused = false;
            this.dgcMain.Name = "dgcMain";
            this.dgcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.memoEdit,
            this.resIcon});
            this.dgcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            resources.ApplyResources(this.gridView2, "gridView2");
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colErrorType,
            this.colTypeImage,
            this.colMessageText});
            this.gridView2.GridControl = this.dgcMain;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridView2.OptionsFilter.AllowFilterEditor = false;
            this.gridView2.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.gridView2.OptionsFilter.AllowMRUFilterList = false;
            this.gridView2.OptionsView.RowAutoHeight = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colErrorType
            // 
            resources.ApplyResources(this.colErrorType, "colErrorType");
            this.colErrorType.FieldName = "ErrorType";
            this.colErrorType.Name = "colErrorType";
            this.colErrorType.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // colTypeImage
            // 
            resources.ApplyResources(this.colTypeImage, "colTypeImage");
            this.colTypeImage.ColumnEdit = this.resIcon;
            this.colTypeImage.FieldName = "TypeImage";
            this.colTypeImage.Name = "colTypeImage";
            this.colTypeImage.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // resIcon
            // 
            resources.ApplyResources(this.resIcon, "resIcon");
            this.resIcon.Name = "resIcon";
            this.resIcon.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // colMessageText
            // 
            resources.ApplyResources(this.colMessageText, "colMessageText");
            this.colMessageText.ColumnEdit = this.memoEdit;
            this.colMessageText.FieldName = "MessageText";
            this.colMessageText.Name = "colMessageText";
            // 
            // memoEdit
            // 
            resources.ApplyResources(this.memoEdit, "memoEdit");
            this.memoEdit.Name = "memoEdit";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOKClose);
            this.panel2.Controls.Add(this.btnNo);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnYes);
            this.panel2.Name = "panel2";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnCancel.Appearance.Font")));
            this.btnCancel.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnCancel.Appearance.GradientMode")));
            this.btnCancel.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Appearance.Image")));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Name = "btnCancel";
            // 
            // btnOKClose
            // 
            resources.ApplyResources(this.btnOKClose, "btnOKClose");
            this.btnOKClose.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnOKClose.Appearance.Font")));
            this.btnOKClose.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnOKClose.Appearance.GradientMode")));
            this.btnOKClose.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnOKClose.Appearance.Image")));
            this.btnOKClose.Appearance.Options.UseFont = true;
            this.btnOKClose.Image = ((System.Drawing.Image)(resources.GetObject("btnOKClose.Image")));
            this.btnOKClose.Name = "btnOKClose";
            // 
            // btnNo
            // 
            resources.ApplyResources(this.btnNo, "btnNo");
            this.btnNo.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnNo.Appearance.Font")));
            this.btnNo.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnNo.Appearance.GradientMode")));
            this.btnNo.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Appearance.Image")));
            this.btnNo.Appearance.Options.UseFont = true;
            this.btnNo.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Image")));
            this.btnNo.Name = "btnNo";
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnExport.Appearance.Font")));
            this.btnExport.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnExport.Appearance.GradientMode")));
            this.btnExport.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Appearance.Image")));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Name = "btnExport";
            // 
            // btnYes
            // 
            resources.ApplyResources(this.btnYes, "btnYes");
            this.btnYes.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnYes.Appearance.Font")));
            this.btnYes.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("btnYes.Appearance.GradientMode")));
            this.btnYes.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("btnYes.Appearance.Image")));
            this.btnYes.Appearance.Options.UseFont = true;
            this.btnYes.Image = ((System.Drawing.Image)(resources.GetObject("btnYes.Image")));
            this.btnYes.Name = "btnYes";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.ivsPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // ivsPanel1
            // 
            resources.ApplyResources(this.ivsPanel1, "ivsPanel1");
            this.ivsPanel1.Controls.Add(this.dgcMain);
            this.ivsPanel1.Controls.Add(this.panel2);
            this.ivsPanel1.Name = "ivsPanel1";
            // 
            // itemLanguage
            // 
            resources.ApplyResources(this.itemLanguage, "itemLanguage");
            this.itemLanguage.Edit = null;
            this.itemLanguage.Id = 137;
            this.itemLanguage.Name = "itemLanguage";
            // 
            // ivsLookUpEdit11
            // 
            resources.ApplyResources(this.ivsLookUpEdit11, "ivsLookUpEdit11");
            this.ivsLookUpEdit11.Name = "ivsLookUpEdit11";
            this.ivsLookUpEdit11.Properties.AccessibleDescription = resources.GetString("ivsLookUpEdit11.Properties.AccessibleDescription");
            this.ivsLookUpEdit11.Properties.AccessibleName = resources.GetString("ivsLookUpEdit11.Properties.AccessibleName");
            this.ivsLookUpEdit11.Properties.AutoHeight = ((bool)(resources.GetObject("ivsLookUpEdit11.Properties.AutoHeight")));
            this.ivsLookUpEdit11.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ivsLookUpEdit11.Properties.Buttons"))))});
            this.ivsLookUpEdit11.Properties.NullValuePrompt = resources.GetString("ivsLookUpEdit11.Properties.NullValuePrompt");
            this.ivsLookUpEdit11.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("ivsLookUpEdit11.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // MessageBoxs
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBoxs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageBoxs_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ivsPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ivsLookUpEdit11.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Ivs.Controls.CustomControls.WinForm.IvsTableLayoutPanel tableLayoutPanel1;
        public Ivs.Controls.CustomControls.WinForm.IvsPanel panel2;
        public Ivs.Controls.CustomControls.WinForm.IvsPanel panel1;
        private Ivs.Controls.CustomControls.WinForm.IvsGridControl dgcMain;
        private Ivs.Controls.CustomControls.WinForm.IvsGridView gridView2;
        private Ivs.Controls.CustomControls.WinForm.IvsGridColumn colErrorType;
        private Ivs.Controls.CustomControls.WinForm.IvsGridColumn colMessageText;
        private Ivs.Controls.CustomControls.WinForm.IvsSimpleButton btnOKClose;
        private Ivs.Controls.CustomControls.WinForm.IvsSimpleButton btnNo;
        private Ivs.Controls.CustomControls.WinForm.IvsSimpleButton btnExport;
        private Ivs.Controls.CustomControls.WinForm.IvsSimpleButton btnYes;
        private Ivs.Controls.CustomControls.WinForm.IvsBarEditItem itemLanguage;
        private Ivs.Controls.CustomControls.WinForm.IvsLookUpEdit1 ivsLookUpEdit11;
        public Ivs.Controls.CustomControls.WinForm.IvsPanel ivsPanel1;
        private Ivs.Controls.CustomControls.WinForm.IvsLabelControl lbl_JP;
        private Ivs.Controls.CustomControls.WinForm.IvsLabelControl lbl_VN;
        private Ivs.Controls.CustomControls.WinForm.IvsLabelControl lbl_EN;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit memoEdit;
        private CustomControls.WinForm.IvsSimpleButton btnCancel;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit resIcon;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeImage;
    }
}