using Ivs.Controls.CustomControls.WinForm;
namespace Ivs.Controls.Forms
{
    partial class MasterReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterReportForm));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.ivsPanel3 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.tlReport = new Ivs.Controls.CustomControls.WinForm.IvsReportMenu();
            this.colValueMember = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDisplayMember = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tableLayoutPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsTableLayoutPanel();
            this.pnFilter = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.PnContainFilter = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.ivsPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.ivsPanel4 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.btnSearch = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.ivsPanel2 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.lblErrorMessage = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.panel2 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.ivsReportManager1 = new Ivs.Controls.CustomControls.WinForm.IvsReportManager();
            this.barManager1 = new Ivs.Controls.CustomControls.WinForm.IvsBarManager();
            this.bar2 = new Ivs.Controls.CustomControls.WinForm.IvsBar();
            this.lblPath = new Ivs.Controls.CustomControls.WinForm.IvsBarStaticItem();
            this.barDockControlTop = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.barDockControlBottom = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.barDockControlLeft = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.barDockControlRight = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.btnCopy = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnAdd = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnEdit = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnDelete = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnRefresh = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnExport = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnPrint = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnClose = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnExcel = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnPdf = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnExcelXlsx = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnText = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnHtml = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnCSV = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.ivsPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlReport)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnFilter.SuspendLayout();
            this.ivsPanel1.SuspendLayout();
            this.ivsPanel4.SuspendLayout();
            this.ivsPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            resources.ApplyResources(this.splitContainerControl1, "splitContainerControl1");
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.ivsPanel3);
            resources.ApplyResources(this.splitContainerControl1.Panel1, "splitContainerControl1.Panel1");
            this.splitContainerControl1.Panel2.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.splitContainerControl1.Panel2, "splitContainerControl1.Panel2");
            this.splitContainerControl1.SplitterPosition = 156;
            // 
            // ivsPanel3
            // 
            this.ivsPanel3.Controls.Add(this.tlReport);
            resources.ApplyResources(this.ivsPanel3, "ivsPanel3");
            this.ivsPanel3.Name = "ivsPanel3";
            // 
            // tlReport
            // 
            this.tlReport.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colValueMember,
            this.colDisplayMember});
            resources.ApplyResources(this.tlReport, "tlReport");
            this.tlReport.Name = "tlReport";
            this.tlReport.OptionsPrint.UsePrintStyles = true;
            this.tlReport.OptionsView.ShowColumns = false;
            this.tlReport.OptionsView.ShowHorzLines = false;
            this.tlReport.OptionsView.ShowIndicator = false;
            this.tlReport.OptionsView.ShowVertLines = false;
            // 
            // colValueMember
            // 
            resources.ApplyResources(this.colValueMember, "colValueMember");
            this.colValueMember.FieldName = "ValueMember";
            this.colValueMember.Name = "colValueMember";
            this.colValueMember.OptionsColumn.AllowEdit = false;
            // 
            // colDisplayMember
            // 
            resources.ApplyResources(this.colDisplayMember, "colDisplayMember");
            this.colDisplayMember.FieldName = "DisplayMember";
            this.colDisplayMember.Name = "colDisplayMember";
            this.colDisplayMember.OptionsColumn.AllowEdit = false;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.pnFilter, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ivsPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // pnFilter
            // 
            this.pnFilter.Controls.Add(this.PnContainFilter);
            this.pnFilter.Controls.Add(this.ivsPanel1);
            resources.ApplyResources(this.pnFilter, "pnFilter");
            this.pnFilter.Name = "pnFilter";
            this.pnFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnFilter_Paint);
            // 
            // PnContainFilter
            // 
            resources.ApplyResources(this.PnContainFilter, "PnContainFilter");
            this.PnContainFilter.Name = "PnContainFilter";
            // 
            // ivsPanel1
            // 
            this.ivsPanel1.Controls.Add(this.ivsPanel4);
            resources.ApplyResources(this.ivsPanel1, "ivsPanel1");
            this.ivsPanel1.Name = "ivsPanel1";
            // 
            // ivsPanel4
            // 
            this.ivsPanel4.Controls.Add(this.btnSearch);
            resources.ApplyResources(this.ivsPanel4, "ivsPanel4");
            this.ivsPanel4.Name = "ivsPanel4";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("btnSearch.Appearance.Font")));
            this.btnSearch.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            // 
            // ivsPanel2
            // 
            this.ivsPanel2.Controls.Add(this.lblErrorMessage);
            resources.ApplyResources(this.ivsPanel2, "ivsPanel2");
            this.ivsPanel2.Name = "ivsPanel2";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblErrorMessage.Appearance.Font")));
            this.lblErrorMessage.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblErrorMessage.Appearance.ForeColor")));
            resources.ApplyResources(this.lblErrorMessage, "lblErrorMessage");
            this.lblErrorMessage.Name = "lblErrorMessage";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ivsReportManager1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // ivsReportManager1
            // 
            resources.ApplyResources(this.ivsReportManager1, "ivsReportManager1");
            this.ivsReportManager1.Name = "ivsReportManager1";
            this.ivsReportManager1.Report = null;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockWindowTabFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barManager1.Form = this;
            this.barManager1.HideBarsWhenMerging = false;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblPath,
            this.btnCopy,
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh,
            this.btnExport,
            this.btnPrint,
            this.btnClose,
            this.btnExcel,
            this.btnPdf,
            this.btnExcelXlsx,
            this.btnText,
            this.btnHtml,
            this.btnCSV});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 15;
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
            // btnCopy
            // 
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Id = 1;
            this.btnCopy.ImageIndex = 0;
            this.btnCopy.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnCopy.ItemAppearance.Normal.Font")));
            this.btnCopy.ItemAppearance.Normal.Options.UseFont = true;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Id = 2;
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnAdd.ItemAppearance.Normal.Font")));
            this.btnAdd.ItemAppearance.Normal.Options.UseFont = true;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Id = 3;
            this.btnEdit.ImageIndex = 0;
            this.btnEdit.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnEdit.ItemAppearance.Normal.Font")));
            this.btnEdit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Id = 4;
            this.btnDelete.ImageIndex = 0;
            this.btnDelete.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnDelete.ItemAppearance.Normal.Font")));
            this.btnDelete.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnRefresh.ItemAppearance.Normal.Font")));
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnExport
            // 
            this.btnExport.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Id = 9;
            this.btnExport.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnExport.ItemAppearance.Normal.Font")));
            this.btnExport.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExport.Name = "btnExport";
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Id = 7;
            this.btnPrint.ImageIndex = 0;
            this.btnPrint.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnPrint.ItemAppearance.Normal.Font")));
            this.btnPrint.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Id = 8;
            this.btnClose.ImageIndex = 0;
            this.btnClose.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnClose.ItemAppearance.Normal.Font")));
            this.btnClose.ItemAppearance.Normal.Options.UseFont = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnExcel
            // 
            resources.ApplyResources(this.btnExcel, "btnExcel");
            this.btnExcel.Id = 9;
            this.btnExcel.Name = "btnExcel";
            // 
            // btnPdf
            // 
            resources.ApplyResources(this.btnPdf, "btnPdf");
            this.btnPdf.Id = 10;
            this.btnPdf.Name = "btnPdf";
            // 
            // btnExcelXlsx
            // 
            resources.ApplyResources(this.btnExcelXlsx, "btnExcelXlsx");
            this.btnExcelXlsx.Id = 11;
            this.btnExcelXlsx.Name = "btnExcelXlsx";
            // 
            // btnText
            // 
            resources.ApplyResources(this.btnText, "btnText");
            this.btnText.Id = 12;
            this.btnText.Name = "btnText";
            // 
            // btnHtml
            // 
            resources.ApplyResources(this.btnHtml, "btnHtml");
            this.btnHtml.Id = 13;
            this.btnHtml.Name = "btnHtml";
            // 
            // btnCSV
            // 
            resources.ApplyResources(this.btnCSV, "btnCSV");
            this.btnCSV.Id = 14;
            this.btnCSV.Name = "btnCSV";
            // 
            // MasterReportForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.Name = "MasterReportForm";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ivsPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlReport)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnFilter.ResumeLayout(false);
            this.ivsPanel1.ResumeLayout(false);
            this.ivsPanel4.ResumeLayout(false);
            this.ivsPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected IvsBarManager barManager1;
        protected IvsBar bar2;
        protected IvsBarStaticItem lblPath;
        protected IvsBarButtonItem btnCopy;
        protected IvsBarButtonItem btnAdd;
        protected IvsBarButtonItem btnEdit;
        protected IvsBarButtonItem btnDelete;
        protected IvsBarButtonItem btnRefresh;
        protected IvsBarButtonItem btnExport;
        protected IvsBarButtonItem btnExcel;
        protected IvsBarButtonItem btnExcelXlsx;
        protected IvsBarButtonItem btnPdf;
        protected IvsBarButtonItem btnText;
        protected IvsBarButtonItem btnHtml;
        protected IvsBarButtonItem btnCSV;
        protected IvsBarButtonItem btnPrint;
        protected IvsBarButtonItem btnClose;
        protected IvsBarDockControl barDockControlTop;
        protected IvsBarDockControl barDockControlBottom;
        protected IvsBarDockControl barDockControlLeft;
        protected IvsBarDockControl barDockControlRight;
        protected IvsTableLayoutPanel tableLayoutPanel1;
        protected IvsPanel panel2;
        protected IvsReportManager ivsReportManager1;
        private IvsPanel ivsPanel3;
        public IvsReportMenu tlReport;
        public DevExpress.XtraTreeList.Columns.TreeListColumn colValueMember;
        public DevExpress.XtraTreeList.Columns.TreeListColumn colDisplayMember;
        private IvsPanel ivsPanel2;
        protected IvsLabelControl lblErrorMessage;
        protected IvsPanel pnFilter;
        protected IvsPanel PnContainFilter;
        protected IvsPanel ivsPanel1;
        private IvsPanel ivsPanel4;
        protected IvsSimpleButton btnSearch;
        protected DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}