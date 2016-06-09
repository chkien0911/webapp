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
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.colMessageText = new Ivs.Controls.CustomControls.WinForm.IvsGridColumn();
            this.memoEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.panel2 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.btnOKClose = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.btnNo = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.btnExport = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.btnYes = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.tableLayoutPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsTableLayoutPanel();
            this.ivsPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.itemLanguage = new Ivs.Controls.CustomControls.WinForm.IvsBarEditItem();
            this.ivsLookUpEdit11 = new Ivs.Controls.CustomControls.WinForm.IvsLookUpEdit1();
            this.btnCancel = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ivsPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ivsLookUpEdit11.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_JP);
            this.panel1.Controls.Add(this.lbl_VN);
            this.panel1.Controls.Add(this.lbl_EN);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // lbl_JP
            // 
            this.lbl_JP.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lbl_JP.Appearance.BackColor")));
            this.lbl_JP.Appearance.ImageIndex = 3;
            this.lbl_JP.Appearance.ImageList = this.imageCollection1;
            resources.ApplyResources(this.lbl_JP, "lbl_JP");
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
            this.lbl_VN.Appearance.ImageIndex = 0;
            this.lbl_VN.Appearance.ImageList = this.imageCollection1;
            resources.ApplyResources(this.lbl_VN, "lbl_VN");
            this.lbl_VN.HtmlImages = this.imageCollection1;
            this.lbl_VN.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.lbl_VN.Name = "lbl_VN";
            // 
            // lbl_EN
            // 
            this.lbl_EN.Appearance.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_EN.Appearance.ImageIndex = 1;
            this.lbl_EN.Appearance.ImageList = this.imageCollection1;
            resources.ApplyResources(this.lbl_EN, "lbl_EN");
            this.lbl_EN.HtmlImages = this.imageCollection1;
            this.lbl_EN.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.lbl_EN.Name = "lbl_EN";
            // 
            // dgcMain
            // 
            resources.ApplyResources(this.dgcMain, "dgcMain");
            this.dgcMain.MainView = this.gridView2;
            this.dgcMain.MoveNextRowWhenLastCellFocused = false;
            this.dgcMain.Name = "dgcMain";
            this.dgcMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit2,
            this.memoEdit});
            this.dgcMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colErrorType,
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
            this.colErrorType.ColumnEdit = this.repositoryItemImageEdit2;
            this.colErrorType.FieldName = "ErrorType";
            this.colErrorType.Name = "colErrorType";
            // 
            // repositoryItemImageEdit2
            // 
            resources.ApplyResources(this.repositoryItemImageEdit2, "repositoryItemImageEdit2");
            this.repositoryItemImageEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemImageEdit2.Buttons"))))});
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
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
            this.memoEdit.Name = "memoEdit";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOKClose);
            this.panel2.Controls.Add(this.btnNo);
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.btnYes);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnOKClose
            // 
            resources.ApplyResources(this.btnOKClose, "btnOKClose");
            this.btnOKClose.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnOKClose.Appearance.Font")));
            this.btnOKClose.Appearance.Options.UseFont = true;
            this.btnOKClose.Image = ((System.Drawing.Image)(resources.GetObject("btnOKClose.Image")));
            this.btnOKClose.Name = "btnOKClose";
            // 
            // btnNo
            // 
            resources.ApplyResources(this.btnNo, "btnNo");
            this.btnNo.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnNo.Appearance.Font")));
            this.btnNo.Appearance.Options.UseFont = true;
            this.btnNo.Image = ((System.Drawing.Image)(resources.GetObject("btnNo.Image")));
            this.btnNo.Name = "btnNo";
            // 
            // btnExport
            // 
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnExport.Appearance.Font")));
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Name = "btnExport";
            // 
            // btnYes
            // 
            resources.ApplyResources(this.btnYes, "btnYes");
            this.btnYes.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnYes.Appearance.Font")));
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
            this.ivsPanel1.Controls.Add(this.dgcMain);
            this.ivsPanel1.Controls.Add(this.panel2);
            resources.ApplyResources(this.ivsPanel1, "ivsPanel1");
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
            this.ivsLookUpEdit11.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ivsLookUpEdit11.Properties.Buttons"))))});
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ivsSimpleButton1.Appearance.Font")));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Name = "btnCancel";
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
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
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
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
    }
}