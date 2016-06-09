using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Ivs.Controls.CustomControls.WinForm;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.Core.Interface;
using Ivs.Core.Logger;
using DevExpress.XtraGrid.Views.Grid;

namespace Ivs.Controls.Forms
{
    public partial class MasterSearchForm : IVSForm
    {
        private static readonly Logger log = new Logger();
        private IvsGridControl _displayGrid = new IvsGridControl();

        protected virtual IvsGridControl displayGrid
        {
            get { return _displayGrid; }
            set { _displayGrid = value; this.ChangeLanguageForGrid(this.displayGrid); }
        }

        protected System.Collections.Generic.List<IDto> ListDto = new System.Collections.Generic.List<IDto>();
        private IvsMessage message = null;
        protected bool isResearch = false;

        #region properties

        protected virtual IDto Dto
        {
            get;
            set;
        }

        protected virtual IBl Bl
        {
            get;
            set;
        }

        protected virtual MessageBoxs MessageBox
        {
            get;
            set;
        }

        protected virtual MasterEditForm EditForm
        {
            get;
            set;
        }

        protected override string FunctionId
        {
            get;
            set;
        }

        public override Dictionary<object, string> LstControls
        {
            get
            {
                Dictionary<object, string> lstControls = new Dictionary<object, string>();
                lstControls.Add(this.btnAdd, btnAdd.Name);
                lstControls.Add(this.btnClose, btnClose.Name);
                lstControls.Add(this.btnCopy, btnCopy.Name);
                lstControls.Add(this.btnDelete, btnDelete.Name);
                lstControls.Add(this.btnEdit, btnEdit.Name);
                lstControls.Add(this.btnExport, btnExport.Name);
                lstControls.Add(this.btnPrint, btnPrint.Name);
                lstControls.Add(this.btnRefresh, btnRefresh.Name);
                lstControls.Add(this.btnSearch, btnSearch.Name);
                return lstControls;
            }
        }

        #endregion properties

        #region constructor

        public MasterSearchForm()
        {
            this.ShowProgressBar();

            InitializeComponent();

            this.HideProgressBar();
        }

        /// <summary>
        /// Set data for Dto
        /// </summary>
        /// <param name="dto"></param>
        public virtual void SetDto(IDto dto)
        {
            this.Dto = dto;
        }

        /// <summary>
        /// Load form
        /// </summary>
        private void MasterSearchForm_Load(object sender, EventArgs e)
        {
            FormLoad();
        }

        protected void MasterSearchForm_Activated(object sender, EventArgs e)
        {
            UserSession.FunctionId = FunctionId;
        }

        protected void displayGrid_DoubleClick(object sender, EventArgs e)
        {
            this.GridDoubleClick();
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

        #endregion constructor

        #region Method

        protected virtual void FormLoad()
        {
            this.LoadControlData();
            this.SetAuthorityControl();
        }

        /// <summary>
        /// Load data for controls (Child forms will override)
        /// </summary>
        protected virtual void LoadControlData()
        {
        }

        /// <summary>
        /// Initalize controls for Search Form
        /// </summary>
        protected virtual void InitControl()
        {
            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = CommonData.StringEmpty;

            #region Add Event For Control

            this.Load += new EventHandler(MasterSearchForm_Load);
            this.btnSearch.Click += new EventHandler(this.SearchData);
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Print);
            this.btnCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CopyAndNewData);
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.NewData);
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.EditData);
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DeleteData);
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RefreshData);
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CloseForm);
            this.btnExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportToXls);
            this.btnExcelXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportToXlsx);
            this.btnPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportToPdf);
            this.btnHtml.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportToHtml);
            this.btnCSV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportToCsv);
            this.btnText.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ExportToText);
            this.lblErrorMessage.Click += new EventHandler(lblErrorMessage_Click);
            this.btnExport.ItemClick += new ItemClickEventHandler(this.Export);
            this.Activated += new EventHandler(MasterSearchForm_Activated);
            this.dockPanel1.VisibilityChanged += new DevExpress.XtraBars.Docking.VisibilityChangedEventHandler(this.dockPanel1_VisibilityChanged);
            this.ivsDockManager1.Sizing += new DevExpress.XtraBars.Docking.SizingEventHandler(this.ivsDockManager1_Sizing);

            #endregion Add Event For Control

            this.SetLanguage();
        }

        /// <summary>
        /// Set language for Title, Path, Grid
        /// </summary>
        public virtual void SetLanguage()
        {
            //set language for Path
            /*
                MS_Factories_Search_Path
                {0}_Search_Path : {0} = this.FunctionGr = MS_Factories
             * */
            this.lblPath.Caption = LanguageUltility.GetString(string.Format("{0}_Search_Path", this.FunctionGr), "Danh mục > Danh mục cơ cấu tổ chức  > Văn phòng");
            //set language for Title
            /*
                MS_Factories_Search_Form
                {0}_Search_Form : {0} = this.FunctionGr = MS_Factories
             * */
            this.Text = LanguageUltility.GetString(string.Format("{0}_Search_Form", this.FunctionGr), "Master Search Form");

            this.ChangeLanguageForGrid(this.displayGrid);

            //this.lblErrorMessage.Text = "";
            if (this.MessageBox != null)
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
        }

        /// <summary>
        /// Change language for gridview
        /// </summary>
        /// <param name="grid"></param>
        protected virtual void ChangeLanguageForGrid(IvsGridControl grid)
        {
            grid.ChangeLanguage();
            //if (grid != null)
            //{
            //    grid.EmbeddedNavigator.TextStringFormat = LanguageUltility.GetString(CommonConstantMessage.COM_MSG_GRID_RECORD_OF_TOTAL, "Mẫu tin {0} của {1}");
            //    if (grid.MainView != null)
            //    {
            //        if (grid.MainView.GetType().Equals(typeof(IvsGridView)))
            //        {
            //            ((IvsGridView)grid.MainView).GroupPanelText = LanguageUltility.GetString(CommonConstantMessage.COM_MSG_HEADERGRID_DRAG, "Kéo một tiêu đề cột lên đây để nhóm cột đó");
            //        }
            //        else if (grid.MainView.GetType().Equals(typeof(IvsBandedGridView)))
            //        {
            //            ((IvsBandedGridView)grid.MainView).GroupPanelText = LanguageUltility.GetString(CommonConstantMessage.COM_MSG_HEADERGRID_DRAG, "Kéo một tiêu đề cột lên đây để nhóm cột đó");
            //        }
            //    }
            //}
        }

        protected virtual System.Collections.Generic.List<IDto> GetSelectedRows()
        {
            return ListDto;
        }

        public override void InitLanguage(string lang, bool isSetCulture = true)
        {
            base.InitLanguage(lang, isSetCulture);
            SetLanguage();
        }

        /// <summary>
        /// Search data
        /// </summary>
        protected virtual void SearchData(object sender, EventArgs e)
        {
            this.SearchData();
            if (ivsDockManager1.IsAutoHide)
            {
                dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            }
        }

        ///// <summary>
        ///// Set Language for screen
        ///// </summary>
        //public virtual void SetLanguage()
        //{
        //    //create I18n class object
        //    I18n i18n = new I18n(CommonData.FunctionId.MasterSearch);
        //    this.lblErrorMessage.Text = this.MessageBox != null ? this.MessageBox.DisplayMessage : i18n.GetString(this.lblErrorMessage.Name);
        //    this.btnSearch.Text = i18n.GetString(this.btnSearch.Name);
        //    this.btnCopy.Caption = i18n.GetString(this.btnCopy.Name);
        //    this.btnAdd.Caption = i18n.GetString(this.btnAdd.Name);
        //    this.btnEdit.Caption = i18n.GetString(this.btnEdit.Name);
        //    this.btnDelete.Caption = i18n.GetString(this.btnDelete.Name);
        //    this.btnRefresh.Caption = i18n.GetString(this.btnRefresh.Name);
        //    this.btnExport.Caption = i18n.GetString(this.btnExport.Name);
        //    this.btnPrint.Caption = i18n.GetString(this.btnPrint.Name);
        //    this.btnClose.Caption = i18n.GetString(this.btnClose.Name);
        //}

        protected virtual void GridDoubleClick(object sender, EventArgs e)
        {
            this.GridDoubleClick();
        }

        protected void CopyAndNewData(object sender, EventArgs e)
        {
            this.CopyAndNewData();
        }

        protected void NewData(object sender, EventArgs e)
        {
            this.NewData();
        }

        protected void EditData(object sender, EventArgs e)
        {
            this.EditData();
        }

        protected void DeleteData(object sender, EventArgs e)
        {
            this.DeleteData();
        }

        protected void RefreshData(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        protected void Print(object sender, EventArgs e)
        {
            this.Print();
        }

        protected void Export(object sender, ItemClickEventArgs e)
        {
            this.Export();
        }

        protected void CloseForm(object sender, EventArgs e)
        {
            this.CloseForm();
        }

        #endregion Method

        protected virtual void Export()
        {
            if (this.btnExport.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnExport.Enabled == false)
            {
                return;
            }
            PopupMenu menu = new PopupMenu();
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
        /// This method is called when click btnExcel button
        /// </summary>
        protected void ExportToXls(object sender, EventArgs e)
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
        protected void ExportToXlsx(object sender, EventArgs e)
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

                //=====Update 15/01/2014(Kien)=====
                //Expand && Collapse detail
                case (Keys.Control | Keys.Space):
                    if (this.displayGrid.Focused)
                    {
                        GridView mainView = ((GridView)this.displayGrid.MainView);
                        if (mainView.IsMasterRow(mainView.FocusedRowHandle))
                        {
                            if (!mainView.GetMasterRowExpanded(mainView.FocusedRowHandle))
                            {
                                //Expand detail
                                mainView.ExpandMasterRow(mainView.FocusedRowHandle);
                            }
                            else
                            {
                                //Collapse detail
                                mainView.CollapseMasterRow(mainView.FocusedRowHandle);
                            }
                        }
                    }
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Processing when click btnSearch or btnRefresh
        /// </summary>
        protected virtual void SearchData()
        {
            this.ShowProgressBar();

            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "SearchData Start");

            #endregion Logger Start

            this.displayGrid.DataSource = null;
            DataTable dtResult = new DataTable();

            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;

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
                message = new IvsMessage(CommonConstantMessage.COM_MSG_ROW_FOUND, dtResult.Rows.Count.ToString());
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
                message = new IvsMessage(CommonConstantMessage.COM_MSG_NO_ROW_SELECTED);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                return;
            }
            if (IsSystemData(ListDto))
            {
                message = new IvsMessage(CommonConstantMessage.COM_MSG_NOT_PERMISSION_EDIT);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                return;
            }
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
                message = new IvsMessage(CommonConstantMessage.COM_MSG_NO_ROW_SELECTED);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                return;
            }

            if (IsSystemData(ListDto))
            {
                message = new IvsMessage(CommonConstantMessage.COM_MSG_NOT_PERMISSION_EDIT);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                return;
            }

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
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "RefreshData Start");

            #endregion Logger Start

            if (this.btnRefresh.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnRefresh.Enabled == false)
            {
                return;
            }

            this.LoadControlData();
            this.SearchData();

            log.GetLogger(this.Name.ToString() + " " + "RefreshData");

            #region logger End

            log.Write(Logger.Level.Debug, "RefreshData End");

            #endregion logger End
        }

        private bool IsSystemData(System.Collections.Generic.List<IDto> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetType().GetProperty(CommonKey.SystemData) != null)
                {
                    string systemDataValue = CommonMethod.ParseString(list[i].GetType().GetProperty(CommonKey.SystemData).GetValue(list[i], null));
                    if (systemDataValue.Equals(CommonData.SystemData.Yes))
                    {
                        return true;
                    }
                }
            }
            return false;
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
                message = new IvsMessage(CommonConstantMessage.COM_MSG_NO_ROW_SELECTED);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                return;
            }
            if (IsSystemData(ListDto))
            {
                message = new IvsMessage(CommonConstantMessage.COM_MSG_NOT_PERMISSION_EDIT);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                return;
            }
            message = new IvsMessage(CommonConstantMessage.COM_MSG_CONFIRM_DELETE);
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
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_DELETE_SUCCESSFULLY);
                    this.MessageBox.Add(message);
                    this.MessageBox.Display(CommonData.MessageType.Ok);
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
        /// Processing when doubleclick gridview
        /// </summary>
        protected virtual void GridDoubleClick()
        {
            if (EditForm == null || EditForm.IsDisposed || (displayGrid != null && displayGrid.RowCount == 0))
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
                message = new IvsMessage(CommonConstantMessage.COM_MSG_NO_ROW_SELECTED);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                return;
            }
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

        /// <summary>
        /// Processing when click btnPrint
        /// </summary>
        protected virtual void Print()
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
        protected virtual void ExportToXls()
        {
            if (this.displayGrid.ExportToXls() == CommonData.IOReturnCode.AccessDenied)
            {
                message = new IvsMessage(CommonConstantMessage.COM_MSG_ACCESS_DENIED);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
            }
        }

        /// <summary>
        /// Processing when click btnExportXlsx
        /// </summary>
        protected virtual void ExportToXlsx()
        {
            if (this.displayGrid.ExportToXlsx() == CommonData.IOReturnCode.AccessDenied)
            {
                message = new IvsMessage(CommonConstantMessage.COM_MSG_ACCESS_DENIED);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
            }
        }

        /// <summary>
        /// Processing when click btnExportPDF
        /// </summary>
        protected virtual void ExportToPdf()
        {
            if (this.displayGrid.ExportToPdf() == CommonData.IOReturnCode.AccessDenied)
            {
                message = new IvsMessage(CommonConstantMessage.COM_MSG_ACCESS_DENIED);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
            }
        }

        /// <summary>
        /// Processing when click btnExportText
        /// </summary>
        protected virtual void ExportToText()
        {
            if (this.displayGrid.ExportToText() == CommonData.IOReturnCode.AccessDenied)
            {
                message = new IvsMessage(CommonConstantMessage.COM_MSG_ACCESS_DENIED);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
            }
        }

        /// <summary>
        /// Processing when click btnExportHtml
        /// </summary>
        protected virtual void ExportToHtml()
        {
            if (this.displayGrid.ExportToHtml() == CommonData.IOReturnCode.AccessDenied)
            {
                message = new IvsMessage(CommonConstantMessage.COM_MSG_ACCESS_DENIED);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
            }
        }

        /// <summary>
        /// Processing when click btnExportCSV
        /// </summary>
        protected virtual void ExportToCsv()
        {
            if (this.displayGrid.ExportToCsv() == CommonData.IOReturnCode.AccessDenied)
            {
                message = new IvsMessage(CommonConstantMessage.COM_MSG_ACCESS_DENIED);
                this.MessageBox.Add(message);
                this.MessageBox.Display(CommonData.MessageType.Ok);
            }
        }

        /// <summary>
        /// Processing when click btnClose
        /// </summary>
        protected void CloseForm()
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