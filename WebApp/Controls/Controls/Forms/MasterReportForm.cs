using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Ivs.Controls.CustomControls.WinForm;
using Ivs.Core.Interface;
using Ivs.Controls.Forms;
using Ivs.Core.Data;
using Ivs.Core.Common;

namespace Ivs.Controls.Forms
{
    public partial class MasterReportForm : IVSForm
    {
        #region properties

        protected DataTable dtResult;
        private IvsReport mRpt;
        private IDto mIDto;
        public IDto GetIDto
        {
            get
            {
                return mIDto;
            }
            set
            {
                mIDto = value;
            }

        }

        protected bool isResearch = false;

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
                lstControls.Add(btnSearch, btnSearch.Name);
                return lstControls;
            }

        }

        protected virtual IvsReport Report
        {
            get;
            set;
        }

        #endregion

        public MasterReportForm()
        {
            InitializeComponent();
        }

        protected virtual void InitControl()
        {
            this.AcceptButton = this.btnSearch;
            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = CommonData.StringEmpty;

            #region Add Event For Control

            this.lblErrorMessage.Click += new EventHandler(lblErrorMessage_Click);
            this.Activated += new EventHandler(MasterReportForm_Activated);
            // this.dockPanel1.VisibilityChanged += new DevExpress.XtraBars.Docking.VisibilityChangedEventHandler(this.dockPanel1_VisibilityChanged);
            // this.ivsDockManager1.Sizing += new DevExpress.XtraBars.Docking.SizingEventHandler(this.ivsDockManager1_Sizing);            
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.tlReport.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(tlReport_CustomDrawNodeCell);
            #endregion

            this.SetLanguage();

            ivsReportManager1.Hide();
        }

        #region Control events

        void tlReport_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.Focused)
            {
                e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);
            }
            else
            {
                e.Appearance.FillRectangle(e.Cache, e.Bounds);
            }
            e.Appearance.DrawString(e.Cache, e.CellText, e.Bounds);
            e.Handled = true;
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            this.ShowReport();
            //dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
        }

        void MasterReportForm_Activated(object sender, EventArgs e)
        {
            UserSession.FunctionId = this.FunctionId;
        }

        void lblErrorMessage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblErrorMessage.Text))
            {
                if (this.MessageBox != null)
                {
                    this.MessageBox.ReDisplay();
                }
            }
        }

        #endregion

        #region Method

        public override void InitLanguage(string lang, bool isSetCulture = true)
        {
            base.InitLanguage(lang, isSetCulture);
            SetLanguage();
        }
        /// <summary>
        /// Set Language for screen
        /// </summary>
        public virtual void SetLanguage()
        {

            /*
                SYS_User_Edit_New_Path
                {0}_{1}_Path
                {0} = SYS_User_Edit = this.FunctionGr
                {1} = New = this.ViewMode.ToString()
             * */
            this.lblPath.Caption = LanguageUltility.GetString(string.Format("{0}_{1}_Path", this.FunctionGr, "Search"), "Danh mục > Danh mục cơ cấu tổ chức  > Văn phòng");
            //set language for Title
            /*
                SYS_User_Edit_Edit_Form
                {0}_{1}_Path
                {0} = SYS_User_Edit = this.FunctionGr
                {1} = New = this.ViewMode.ToString()
             * */
            this.Text = LanguageUltility.GetString(string.Format("{0}_{1}_Form", this.FunctionGr, "Search"), "Master Report Form");

            if (this.MessageBox != null)
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
        }


        /// <summary>
        /// Shows the report.
        /// </summary>
        public virtual void ShowReport()
        {
            this.ShowProgressBar();

            dtResult = new DataTable();

            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;
            if (this.Dto != null)
            {
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

                // Start update by Nguyen Thai An on 30/7/2013 for DMP project

                // Code old
                //if (iReturnCode == CommonData.DbReturnCode.Succeed)
                //{
                //    if (!isResearch)
                //    {
                //        this.Report.DataSource = dtResult;
                //        this.Report.BindData();
                //        //Display report
                //        ivsReportManager1.Report = this.Report;
                //        ivsReportManager1.ShowReport();
                //        //Display message
                //        message = new Ivs.Ihrm.Core.Data.Message("CMN002", dtResult.Rows.Count);
                //        this.MessageBox.Add(message);
                //        this.MessageBox.Display(Ivs.Ihrm.Core.Data.CommonData.MessageType.Ok);
                //        this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                //    }
                //}
                //else
                //{
                //    ProcessDbExcetion(iReturnCode);
                //}

                //code new
                if (iReturnCode == CommonData.DbReturnCode.Succeed)
                {
                    if (!isResearch)
                    {
                        //this.Report.DataSource = dtResult;
                        //this.Report.BindData();
                        ////Display report
                        //ivsReportManager1.Report = this.Report;
                        //ivsReportManager1.ShowReport();
                        ////Display message
                        //message = new Ivs.Ihrm.Core.Data.Message("CMN002", dtResult.Rows.Count);
                        //this.MessageBox.Add(message);
                        //this.MessageBox.Display(Ivs.Ihrm.Core.Data.CommonData.MessageType.Ok);
                        //this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;

                        if (dtResult.Rows.Count > 0)
                        {
                            //this.Report = new IvsReport();
                            this.Report.DataSource = dtResult;
                            this.Report.BindData();
                            //Display report
                            ivsReportManager1.Report = this.Report;
                            ivsReportManager1.ShowReport();
                            ivsReportManager1.Show();
                            //Display message
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_ROW_FOUND, dtResult.Rows.Count);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                        }
                        else
                        {
                            
                            //ivsReportManager1.ReCreate();
                            ivsReportManager1.Hide();
                            //this.lblErrorMessage.Text = this.ProcessDbExcetion(8); // data not found
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_ROW_FOUND, dtResult.Rows.Count);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
                        }

                    }
                }
                else
                {
                    ProcessDbExcetion(iReturnCode);
                    ivsReportManager1.Hide();
                }
                // End update by Nguyen Thai An on 30/7/2013 for DMP project
            }

            this.HideProgressBar();
        }

        #endregion

        private void pnFilter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}