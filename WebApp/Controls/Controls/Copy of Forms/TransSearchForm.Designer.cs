
using Ivs.Controls.CustomControls.WinForm;
namespace Ivs.Controls.Forms
{
    partial class TransSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransSearchForm));
            this.barManager1 = new Ivs.Controls.CustomControls.WinForm.IvsBarManager();
            this.bar2 = new Ivs.Controls.CustomControls.WinForm.IvsBar();
            this.lblPath = new Ivs.Controls.CustomControls.WinForm.IvsBarStaticItem();
            this.bar3 = new Ivs.Controls.CustomControls.WinForm.IvsBar();
            this.btnCopy = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnAdd = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnEdit = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnDelete = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnRefresh = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnExport = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnPrint = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnClose = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.barDockControlTop = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.barDockControlBottom = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.barDockControlLeft = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.barDockControlRight = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.btnExcel = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnPdf = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnExcelXlsx = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnText = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnHtml = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnCSV = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.tableLayoutPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsTableLayoutPanel();
            this.panel2 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.ivsPanel2 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.lblErrorMessage = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.btnSearch = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.ivsDockManager1 = new Ivs.Controls.CustomControls.WinForm.IvsDockManager();
            this.dockPanel1 = new Ivs.Controls.CustomControls.WinForm.IvsDockPanel();
            this.panel1 = new Ivs.Controls.CustomControls.WinForm.IvsDockControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.ivsPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ivsDockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.bar2.Text = "Main menu";
            // 
            // lblPath
            // 
            this.lblPath.Caption = "Danh mục > Danh mục cơ cấu tổ chức  > Văn phòng";
            this.lblPath.Id = 0;
            this.lblPath.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // btnCopy
            // 
            this.btnCopy.Caption = "Sao chép dòng";
            this.btnCopy.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCopy.Glyph")));
            this.btnCopy.Id = 1;
            this.btnCopy.ImageIndex = 0;
            this.btnCopy.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCopy.ItemAppearance.Normal.Options.UseFont = true;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Thêm";
            this.btnAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("btnAdd.Glyph")));
            this.btnAdd.Id = 2;
            this.btnAdd.ImageIndex = 0;
            this.btnAdd.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F);
            this.btnAdd.ItemAppearance.Normal.Options.UseFont = true;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Sửa";
            this.btnEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEdit.Glyph")));
            this.btnEdit.Id = 3;
            this.btnEdit.ImageIndex = 0;
            this.btnEdit.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F);
            this.btnEdit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDelete.Glyph")));
            this.btnDelete.Id = 4;
            this.btnDelete.ImageIndex = 0;
            this.btnDelete.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F);
            this.btnDelete.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Làm mới";
            this.btnRefresh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Glyph")));
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageIndex = 0;
            this.btnRefresh.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F);
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnExport
            // 
            this.btnExport.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnExport.Caption = "Xuất dữ liệu";
            this.btnExport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExport.Glyph")));
            this.btnExport.Id = 9;
            this.btnExport.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F);
            this.btnExport.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExport.Name = "btnExport";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrint.Glyph")));
            this.btnPrint.Id = 7;
            this.btnPrint.ImageIndex = 0;
            this.btnPrint.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F);
            this.btnPrint.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 8;
            this.btnClose.ImageIndex = 0;
            this.btnClose.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F);
            this.btnClose.ItemAppearance.Normal.Options.UseFont = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnClose.ShortcutKeyDisplayString = "F12";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1000, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 508);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1000, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 486);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1000, 22);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 486);
            // 
            // btnExcel
            // 
            this.btnExcel.Caption = "Excel(.xls)";
            this.btnExcel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExcel.Glyph")));
            this.btnExcel.Id = 9;
            this.btnExcel.Name = "btnExcel";
            // 
            // btnPdf
            // 
            this.btnPdf.Caption = "PDF";
            this.btnPdf.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPdf.Glyph")));
            this.btnPdf.Id = 10;
            this.btnPdf.Name = "btnPdf";
            // 
            // btnExcelXlsx
            // 
            this.btnExcelXlsx.Caption = "Excel(.xlsx)";
            this.btnExcelXlsx.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExcelXlsx.Glyph")));
            this.btnExcelXlsx.Id = 11;
            this.btnExcelXlsx.Name = "btnExcelXlsx";
            // 
            // btnText
            // 
            this.btnText.Caption = "Text";
            this.btnText.Glyph = ((System.Drawing.Image)(resources.GetObject("btnText.Glyph")));
            this.btnText.Id = 12;
            this.btnText.Name = "btnText";
            // 
            // btnHtml
            // 
            this.btnHtml.Caption = "Html";
            this.btnHtml.Glyph = ((System.Drawing.Image)(resources.GetObject("btnHtml.Glyph")));
            this.btnHtml.Id = 13;
            this.btnHtml.Name = "btnHtml";
            // 
            // btnCSV
            // 
            this.btnCSV.Caption = "CSV";
            this.btnCSV.Glyph = ((System.Drawing.Image)(resources.GetObject("btnCSV.Glyph")));
            this.btnCSV.Id = 14;
            this.btnCSV.Name = "btnCSV";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ivsPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 152);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 356);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(992, 321);
            this.panel2.TabIndex = 0;
            // 
            // ivsPanel2
            // 
            this.ivsPanel2.Controls.Add(this.lblErrorMessage);
            this.ivsPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ivsPanel2.Location = new System.Drawing.Point(4, 4);
            this.ivsPanel2.Name = "ivsPanel2";
            this.ivsPanel2.Size = new System.Drawing.Size(992, 20);
            this.ivsPanel2.TabIndex = 1;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorMessage.Location = new System.Drawing.Point(0, 0);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(992, 20);
            this.lblErrorMessage.TabIndex = 5;
            this.lblErrorMessage.Text = "Error message";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(884, 59);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 40);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Tìm Kiếm";
            // 
            // ivsDockManager1
            // 
            this.ivsDockManager1.AllowResize = false;
            this.ivsDockManager1.DockingOptions.FloatOnDblClick = false;
            this.ivsDockManager1.DockingOptions.ShowCloseButton = false;
            this.ivsDockManager1.DockingOptions.ShowMaximizeButton = false;
            this.ivsDockManager1.Form = this;
            this.ivsDockManager1.MenuManager = this.barManager1;
            this.ivsDockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1});
            this.ivsDockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Bar",
            "Ivs.Controls.CustomControls.WinForm.IvsBarManager",
            "Ivs.Controls.CustomControls.WinForm.IvsBarDockControl",
            "Ivs.Controls.CustomControls.WinForm.IvsBar",
            "Ivs.Controls.CustomControls.WinForm.IvsBarStaticItem"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.panel1);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockPanel1.ID = new System.Guid("54a6c0b8-93bb-4c8d-9032-fc5db84c21f1");
            this.dockPanel1.Location = new System.Drawing.Point(0, 22);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.AllowDockAsTabbedDocument = false;
            this.dockPanel1.Options.AllowDockBottom = false;
            this.dockPanel1.Options.AllowDockFill = false;
            this.dockPanel1.Options.AllowDockLeft = false;
            this.dockPanel1.Options.AllowDockRight = false;
            this.dockPanel1.Options.AllowFloating = false;
            this.dockPanel1.Options.FloatOnDblClick = false;
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.Options.ShowMaximizeButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 130);
            this.dockPanel1.Size = new System.Drawing.Size(1000, 130);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 103);
            this.panel1.TabIndex = 0;
            // 
            // TransSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 535);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.MaximizeBox = false;
            this.Name = "TransSearchForm";
            this.ShowInTaskbar = false;
            this.Text = "TransSearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ivsPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ivsDockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected Ivs.Controls.CustomControls.WinForm.IvsBarManager barManager1;
        protected Ivs.Controls.CustomControls.WinForm.IvsBar bar2;
        protected Ivs.Controls.CustomControls.WinForm.IvsBar bar3;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnCopy;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnAdd;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnEdit;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnDelete;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnRefresh;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnExport;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnExcel;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnExcelXlsx;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnPdf;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnText;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnHtml;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnCSV;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnPrint;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem btnClose;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarDockControl barDockControlTop;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarDockControl barDockControlBottom;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarDockControl barDockControlLeft;
        protected Ivs.Controls.CustomControls.WinForm.IvsBarDockControl barDockControlRight;
        public IvsBarStaticItem lblPath;
        protected IvsTableLayoutPanel tableLayoutPanel1;
        private IvsPanel ivsPanel2;
        protected IvsSimpleButton btnSearch;
        protected IvsPanel panel2;
        protected IvsLabelControl lblErrorMessage;
        protected Ivs.Controls.CustomControls.WinForm.IvsDockPanel dockPanel1;
        protected Ivs.Controls.CustomControls.WinForm.IvsDockControlContainer panel1;
        protected Ivs.Controls.CustomControls.WinForm.IvsDockManager ivsDockManager1;
    }
}