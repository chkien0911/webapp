using System;
using System.Data;
using System.Windows.Forms;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.Core.Interface;
using Ivs.Core.Logger;

namespace Ivs.Controls.Forms
{
    public partial class TransSearchForm : Ivs.Controls.CustomControls.WinForm.IVSForm
    {
        protected Ivs.Controls.CustomControls.WinForm.IvsGridControl displayGrid = new Ivs.Controls.CustomControls.WinForm.IvsGridControl();
        protected System.Collections.Generic.List<IDto> ListDto = new System.Collections.Generic.List<IDto>();
        protected CommonData.Mode movingMode;
        private static readonly Logger log = new Logger();

        protected bool isResearch = false;

        #region properties

        protected virtual IDto Dto
        {
            get;
            set;
        }

        protected virtual string Code
        {
            get;
            set;
        }

        protected virtual Ivs.Core.Interface.IBl Bl
        {
            get;
            set;
        }

        protected virtual MessageBoxs MessageBox
        {
            get;
            set;
        }

        protected virtual Ivs.Controls.Forms.TransEditForm EditForm
        {
            get;
            set;
        }

        protected override string FunctionId
        {
            get;
            set;
        }

        #endregion properties

        public TransSearchForm()
        {
            InitializeComponent();
            lblErrorMessage.Visible = true;

            #region Add Event For Control

            this.btnSearch.Click += new EventHandler(this.SearchData);
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Print);
            this.btnCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CopyAndNewData);
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NewData);
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.EditData);
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DeleteData);
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RefreshData);
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CloseForm);
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Export);
            this.btnExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportToXls);
            this.btnExcelXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportToXlsx);
            this.btnPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportToPdf);
            this.btnHtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportToHtml);
            this.btnCSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportToCsv);
            this.btnText.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportToText);
            this.lblErrorMessage.Click += new EventHandler(lblErrorMessage_Click);
            this.Activated += new EventHandler(TransSearchForm_Activated);
            this.ivsDockManager1.Sizing += new DevExpress.XtraBars.Docking.SizingEventHandler(this.ivsDockManager1_Sizing);
            this.dockPanel1.VisibilityChanged += new DevExpress.XtraBars.Docking.VisibilityChangedEventHandler(this.dockPanel1_VisibilityChanged);

            #endregion Add Event For Control

            SetAuthorityControl();
        }

        private void TransSearchForm_Activated(object sender, EventArgs e)
        {
            UserSession.FunctionId = FunctionId;
        }

        private void ivsDockManager1_Sizing(object sender, DevExpress.XtraBars.Docking.SizingEventArgs e)
        {
            if (!this.ivsDockManager1.AllowResize)
            {
                e.Cancel = true;
            }
        }

        private void lblErrorMessage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblErrorMessage.Text))
            {
                if (this.MessageBox != null)
                {
                    this.MessageBox.ReDisplay();
                }
            }
        }

        private void dockPanel1_VisibilityChanged(object sender, DevExpress.XtraBars.Docking.VisibilityChangedEventArgs e)
        {
            if (this.dockPanel1.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
            {
                this.panel1.Focus();
                this.btnSearch.Select();
                this.dockPanel1.Text = "";
            }
            else
            {
                this.displayGrid.Focus();
                this.dockPanel1.Text = "▼";
            }
        }

        protected virtual System.Collections.Generic.List<IDto> GetSelectedRows()
        {
            return ListDto;
        }

        protected void SearchData(object sender, EventArgs e)
        {
            this.SearchData();
            if (ivsDockManager1.IsAutoHide)
            {
                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            }
        }

        /// <summary>
        /// Set authority for screen
        /// </summary>
        public virtual void SetLanguage()
        {
            //create I18n class object
            I18n i18n = new I18n(CommonData.FunctionId.TransSearch);
            this.lblErrorMessage.Text = this.MessageBox != null ? this.MessageBox.DisplayMessage : i18n.GetString(this.lblErrorMessage.Name);
            this.btnSearch.Text = i18n.GetString(this.btnSearch.Name);
            this.btnCopy.Caption = i18n.GetString(this.btnCopy.Name);
            this.btnAdd.Caption = i18n.GetString(this.btnAdd.Name);
            this.btnEdit.Caption = i18n.GetString(this.btnEdit.Name);
            this.btnDelete.Caption = i18n.GetString(this.btnDelete.Name);
            this.btnRefresh.Caption = i18n.GetString(this.btnRefresh.Name);
            this.btnExport.Caption = i18n.GetString(this.btnExport.Name);
            this.btnPrint.Caption = i18n.GetString(this.btnPrint.Name);
            this.btnClose.Caption = i18n.GetString(this.btnClose.Name);
            //this.lblPath.Caption = i18n.GetString(this.lblPath.Name);
        }

        protected void Export(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Export();
        }

        protected virtual void GridDoubleClick(object sender, EventArgs e)
        {
            this.GridDoubleClick();
        }

        protected void CopyAndNewData(object sender, EventArgs e)
        {
            this.CopyAndNewData();
        }

        protected virtual void NewData(object sender, EventArgs e)
        {
            this.NewData();
        }

        protected virtual void EditData(object sender, EventArgs e)
        {
            this.EditData();
        }

        protected virtual void DeleteData(object sender, EventArgs e)
        {
            this.DeleteData();
        }

        protected virtual void RefreshData(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        protected void Print(object sender, EventArgs e)
        {
            this.Print();
        }

        protected virtual void CloseForm(object sender, EventArgs e)
        {
            this.CloseForm();
        }

        /// <summary>
        /// This method is called when click btnExcel button
        /// </summary>
        protected virtual void ExportToXls(object sender, EventArgs e)
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "ExportToXls Start");

            #endregion Logger Start

            this.ExportToXls();

            #region Logger End

            log.Write(Logger.Level.Debug, "ExportToXls End");

            #endregion Logger End
        }

        /// <summary>
        /// This method is called when click btnExcelXlsx button
        /// </summary>
        protected virtual void ExportToXlsx(object sender, EventArgs e)
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "ExportToXlsx Start");

            #endregion Logger Start

            this.ExportToXlsx();

            #region Logger End

            log.Write(Logger.Level.Debug, "ExportToXlsx End");

            #endregion Logger End
        }

        /// <summary>
        /// This method is called when click btnPdf button
        /// </summary>
        protected void ExportToPdf(object sender, EventArgs e)
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "ExportToPdf Start");

            #endregion Logger Start

            this.ExportToPdf();

            #region Logger End

            log.Write(Logger.Level.Debug, "ExportToPdf End");

            #endregion Logger End
        }

        /// <summary>
        /// This method is called when click btnText button
        /// </summary>
        protected void ExportToText(object sender, EventArgs e)
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "ExportToText Start");

            #endregion Logger Start

            this.ExportToText();

            #region Logger End

            log.Write(Logger.Level.Debug, "ExportToText End");

            #endregion Logger End
        }

        /// <summary>
        /// This method is called when click btnHtml button
        /// </summary>
        protected void ExportToHtml(object sender, EventArgs e)
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "ExportToHtml Start");

            #endregion Logger Start

            this.ExportToHtml();

            #region Logger End

            log.Write(Logger.Level.Debug, "ExportToHtml End");

            #endregion Logger End
        }

        /// <summary>
        /// This method is called when click btnCSV button
        /// </summary>
        protected void ExportToCsv(object sender, EventArgs e)
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "ExportToCsv Start");

            #endregion Logger Start

            this.ExportToCsv();

            #region Logger End

            log.Write(Logger.Level.Debug, "ExportToCsv End");

            #endregion Logger End
        }

        /// <summary>
        /// Override ProcessCmdKey method (HotKey processing)
        /// </summary>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            switch (keyData)
            {
                //close
                case Keys.Escape:
                    this.btnClose.PerformClick();
                    return true;
                //help
                case Keys.F1:
                    return true;
                //copy data
                case Keys.F2:
                    this.btnCopy.PerformClick();
                    return true;
                //new data
                case Keys.F3:
                    this.btnAdd.PerformClick();
                    return true;
                //edit data
                case Keys.F4:
                    this.btnEdit.PerformClick();
                    return true;
                //refresh data
                case Keys.F5:
                    this.btnRefresh.PerformClick();
                    return true;
                //view data
                case Keys.F6:
                    this.GridDoubleClick();
                    return true;
                //delete data
                case Keys.F7:
                    this.btnDelete.PerformClick();
                    return true;
                //import
                case Keys.F8:
                    this.Import();
                    return true;
                //export
                case Keys.F9:
                    this.btnExport.PerformClick();
                    return true;
                //print
                case Keys.F10:
                    this.btnPrint.PerformClick();
                    return true;
                //Show & Hide panel
                case (Keys.Control | Keys.F2):
                    if (this.dockPanel1.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                    {
                        this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
                    }
                    else
                    {
                        this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible;
                    }
                    return true;

                //=====Update 17/05/2013(Kien)=====
                case (Keys.Shift | Keys.Tab):
                    barManager1.Bars[1].ItemLinks[0].Focus();
                    return true;
                //=====EndUpdate===================
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected virtual void Export()
        {
            if (btnExport.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnExport.Enabled == false)
            {
                return;
            }
            DevExpress.XtraBars.PopupMenu menu = new DevExpress.XtraBars.PopupMenu();
            // Bind the menu to a bar manager.
            menu.Manager = barManager1;
            // Add two items that belong to the bar manager.
            menu.ItemLinks.Add(btnExcel);
            menu.ItemLinks.Add(btnExcelXlsx);
            menu.ItemLinks.Add(btnPdf);
            menu.ItemLinks.Add(btnText);
            menu.ItemLinks.Add(btnHtml);
            menu.ItemLinks.Add(btnCSV);
            this.btnExport.DropDownControl = menu;
            int index = bar3.ItemLinks.Count - 3 < 0 ? 0 : bar3.ItemLinks.Count - 3;
            System.Drawing.Rectangle rec = bar3.ItemLinks[index].ScreenBounds;
            menu.ShowPopup(new System.Drawing.Point(rec.X, rec.Y));
        }

        /// <summary>
        /// Processing when search data
        /// </summary>
        public virtual void SearchData()
        {
            this.ShowProgressBar();

            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "SearchData Start");

            #endregion Logger Start

            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;
            this.displayGrid.DataSource = null;
            DataTable dtResult = new DataTable();
            int iReturnCode = Bl.SearchData(this.Dto, out dtResult);
            /// Succeed: search successful, don't show message error
            /// AccessDenied: Access denied, login to database fail(invalid username, invalid password), show message error
            /// InvalidHost: Invalid host, cannot find server(host) that set in app config file, show message error
            /// InvalidDatabase: Invalid database, cannot find database that set in DbConfig file, show message error
            /// LostConnection: Lost connection, cannot connect to database because lost connection, show message error
            /// DuplicateKey: Duplicate key: insert Primary Key or Unique Key that already exist in database, show message error
            /// ForgeignKeyNotExist: Forgeign key not exist: insert a foreign key that not exist in primary key, show message error
            /// ForeignKeyViolation: Foreign Key Violation: Foreign Key Violation (delete primary key that is foreign key in other table), show message error
            /// DataNotFound: Data not found: Delete or Update data that not exist in database, show message error
            /// ExceptionOccured: Exception occured: other exception

            if (iReturnCode == CommonData.DbReturnCode.Succeed)
            {
                this.displayGrid.DataSource = dtResult;
                message = new IvsMessage("CMN002", dtResult.Rows.Count);
                this.MessageBox.Add(message);
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                if (!isResearch)
                {
                    this.MessageBox.Display(CommonData.MessageType.Ok);
                }
            }
            else
            {
                ProcessDbExcetion(iReturnCode);
            }

            #region Logger End

            log.Write(Logger.Level.Debug, "SearchData End");

            #endregion Logger End

            this.HideProgressBar();
        }

        /// <summary>
        /// Processing when click btnCopy
        /// </summary>
        protected void CopyAndNewData()
        {
            if (this.btnCopy.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnCopy.Enabled == false)
            {
                return;
            }

            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "CopyAndNewData Start");

            #endregion Logger Start

            this.lblErrorMessage.Text = CommonData.StringEmpty;
            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;

            ListDto = GetSelectedRows();

            if (ListDto.Count <= 0)
            {
                message = new IvsMessage("CMN008");
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                return;
            }
            this.movingMode = CommonData.Mode.New;
            EditForm.ListDto = ListDto;
            EditForm.ViewMode = CommonData.Mode.New;
            EditForm.Open();
            EditForm = null;

            #region Logger End

            log.Write(Logger.Level.Debug, "CopyAndNewData End");

            #endregion Logger End
        }

        /// <summary>
        /// Processing when click btnNew
        /// </summary>
        protected void NewData()
        {
            if (this.btnAdd.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnAdd.Enabled == false)
            {
                return;
            }

            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "NewData Start");

            #endregion Logger Start

            this.lblErrorMessage.Text = CommonData.StringEmpty;
            this.movingMode = CommonData.Mode.New;
            EditForm.ViewMode = CommonData.Mode.New;
            EditForm.Open();
            EditForm = null;

            #region Logger End

            log.Write(Logger.Level.Debug, "NewData End");

            #endregion Logger End
        }

        /// <summary>
        /// Processing when click btnEdit
        /// </summary>
        protected virtual void EditData()
        {
            if (this.btnEdit.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnEdit.Enabled == false)
            {
                return;
            }

            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "EditData Start");

            #endregion Logger Start

            this.lblErrorMessage.Text = CommonData.StringEmpty;
            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;

            ListDto = GetSelectedRows();

            if (ListDto.Count <= 0)
            {
                message = new IvsMessage("CMN008");
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                return;
            }
            this.movingMode = CommonData.Mode.Edit;
            EditForm.ListDto = ListDto;
            EditForm.ViewMode = CommonData.Mode.Edit;
            EditForm.Open();
            EditForm = null;

            // Resarch data after edit
            isResearch = true;
            this.SearchData();
            log.GetLogger(this.Name.ToString());
            isResearch = false;

            #region Logger End

            log.Write(Logger.Level.Debug, "EditData End");

            #endregion Logger End
        }

        /// <summary>
        /// Processing when click btnRefresh
        /// </summary>
        protected void RefreshData()
        {
            if (this.btnRefresh.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnRefresh.Enabled == false)
            {
                return;
            }

            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "RefreshData Start");

            #endregion Logger Start

            this.SearchData();
            log.GetLogger(this.Name.ToString());

            #region Logger End

            log.Write(Logger.Level.Debug, "RefreshData End");

            #endregion Logger End
        }

        /// <summary>
        /// Processing when click btnDelete
        /// </summary>
        protected virtual void DeleteData()
        {
            if (this.btnDelete.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnDelete.Enabled == false)
            {
                return;
            }

            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "DeleteData Start");

            #endregion Logger Start

            this.lblErrorMessage.Text = CommonData.StringEmpty;
            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;

            ListDto = GetSelectedRows();
            if (ListDto.Count <= 0)
            {
                message = new IvsMessage("CMN008");
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                return;
            }
            message = new IvsMessage("CMN011");
            this.MessageBox.Add(message);
            CommonData.MessageTypeResult result = this.MessageBox.Display(CommonData.MessageType.YesNo);
            if (result == CommonData.MessageTypeResult.Yes)
            {
                int iReturnCode = Bl.DeleteData(ListDto);
                /// Succeed: Delete successful, don't show message error, refresh Gird
                /// AccessDenied: Access denied, login to database fail(invalid username, invalid password), show message error
                /// InvalidHost: Invalid host, cannot find server(host) that set in app config file, show message error
                /// InvalidDatabase: Invalid database, cannot find database that set in DbConfig file, show message error
                /// LostConnection: Lost connection, cannot connect to database because lost connection, show message error
                /// DuplicateKey: Duplicate key: insert Primary Key or Unique Key that already exist in database, show message error
                /// ForgeignKeyNotExist: Forgeign key not exist: insert a foreign key that not exist in primary key, show message error
                /// ForeignKeyViolation: Foreign Key Violation: Foreign Key Violation (delete primary key that is foreign key in other table), show message error
                /// DataNotFound: Data not found: Delete or Update data that not exist in database, show message error
                /// ExceptionOccured: Exception occured: other exception

                if (iReturnCode == CommonData.DbReturnCode.Succeed)
                {
                    message = new IvsMessage("CMN005");
                    this.MessageBox.Add(message);
                    this.MessageBox.Display(CommonData.MessageType.Ok);
                    // Resarch data after delete
                    isResearch = true;
                    this.SearchData();
                    isResearch = false;
                }
                else
                {
                    ProcessDbExcetion(iReturnCode);
                }
            }

            #region Logger End

            log.Write(Logger.Level.Debug, "DeleteData End");

            #endregion Logger End
        }

        /// <summary>
        /// Processing when click btnPrint
        /// </summary>
        protected void Print()
        {
            if (this.btnPrint.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnPrint.Enabled == false)
            {
                return;
            }

            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "Print Start");

            #endregion Logger Start

            this.displayGrid.ShowRibbonPrintPreview();

            #region Logger End

            log.Write(Logger.Level.Debug, "Print End");

            #endregion Logger End
        }

        /// <summary>
        /// Processing when click btnImport
        /// </summary>
        protected virtual void Import()
        {
            return;
        }

        /// <summary>
        /// Processing when click btnExportXls
        /// </summary>
        protected void ExportToXls()
        {
            if (this.displayGrid.ExportToXls() == CommonData.IOReturnCode.AccessDenied)
            {
                //message = new IvsMessage("CMN017");
                //this.MessageBox.Add(message);
                //this.MessageBox.Display(CommonData.MessageType.Ok);
                //MessageBox.Show("IO Access Denied !");
            }
        }

        /// <summary>
        /// Processing when click btnExportXlsx
        /// </summary>
        protected void ExportToXlsx()
        {
            if (this.displayGrid.ExportToXlsx() == CommonData.IOReturnCode.AccessDenied)
            {
                //message = new IvsMessage("CMN017");
                //this.MessageBox.Add(message);
                //this.MessageBox.Display(CommonData.MessageType.Ok);
                //MessageBox.Show("IO Access Denied !");
            }
        }

        /// <summary>
        /// Processing when click btnExportPDF
        /// </summary>
        protected void ExportToPdf()
        {
            if (this.displayGrid.ExportToPdf() == CommonData.IOReturnCode.AccessDenied)
            {
                //message = new IvsMessage("CMN017");
                //this.MessageBox.Add(message);
                //this.MessageBox.Display(CommonData.MessageType.Ok);
                //MessageBox.Show("IO Access Denied !");
            }
        }

        /// <summary>
        /// Processing when click btnExportText
        /// </summary>
        protected void ExportToText()
        {
            if (this.displayGrid.ExportToText() == CommonData.IOReturnCode.AccessDenied)
            {
                //message = new IvsMessage("CMN017");
                //this.MessageBox.Add(message);
                //this.MessageBox.Display(CommonData.MessageType.Ok);
                //MessageBox.Show("IO Access Denied !");
            }
        }

        /// <summary>
        /// Processing when click btnExportHtml
        /// </summary>
        protected void ExportToHtml()
        {
            if (this.displayGrid.ExportToHtml() == CommonData.IOReturnCode.AccessDenied)
            {
                //message = new IvsMessage("CMN017");
                //this.MessageBox.Add(message);
                //this.MessageBox.Display(CommonData.MessageType.Ok);
                //MessageBox.Show("IO Access Denied !");
            }
        }

        /// <summary>
        /// Processing when click btnExportCSV
        /// </summary>
        protected void ExportToCsv()
        {
            if (this.displayGrid.ExportToCsv() == CommonData.IOReturnCode.AccessDenied)
            {
                //message = new IvsMessage("CMN017");
                //this.MessageBox.Add(message);
                //this.MessageBox.Display(CommonData.MessageType.Ok);
                //MessageBox.Show("IO Access Denied !");
            }
        }

        /// <summary>
        /// Processing when click btnClose
        /// </summary>
        protected virtual void CloseForm()
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "CloseForm Start");

            #endregion Logger Start

            this.Close();

            #region Logger End

            log.Write(Logger.Level.Debug, "CloseForm End");

            #endregion Logger End
        }

        protected void GridDoubleClick()
        {
            if (EditForm == null || EditForm.IsDisposed)
            {
                return;
            }

            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "GridDoubleClick Start");

            #endregion Logger Start

            this.lblErrorMessage.Text = CommonData.StringEmpty;
            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;
            ListDto = GetSelectedRows();
            if (ListDto.Count <= 0)
            {
                message = new IvsMessage("CMN008");
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                return;
            }
            this.movingMode = CommonData.Mode.View;
            EditForm.ListDto = ListDto;
            EditForm.ViewMode = CommonData.Mode.View;
            EditForm.Open();
            EditForm = null;

            // Resarch data after edit
            isResearch = true;
            this.SearchData();
            log.GetLogger(this.Name.ToString());
            isResearch = false;

            #region Logger End

            log.Write(Logger.Level.Debug, "GridDoubleClick End");

            #endregion Logger End
        }

        protected override void SetAuthorityControl()
        {
            if (this.IsAuthority(CommonData.OperId.Add) == CommonData.IsAuthority.Deny)
            {
                btnCopy.Enabled = false;
                btnAdd.Enabled = false;
            }
            if (this.IsAuthority(CommonData.OperId.Edit) == CommonData.IsAuthority.Deny)
            {
                btnEdit.Enabled = false;
            }
            if (this.IsAuthority(CommonData.OperId.Delete) == CommonData.IsAuthority.Deny)
            {
                btnDelete.Enabled = false;
            }
            if (this.IsAuthority(CommonData.OperId.Export) == CommonData.IsAuthority.Deny)
            {
                btnExport.Enabled = false;
            }
            if (this.IsAuthority(CommonData.OperId.Print) == CommonData.IsAuthority.Deny)
            {
                btnPrint.Enabled = false;
            }
        }
    }
}