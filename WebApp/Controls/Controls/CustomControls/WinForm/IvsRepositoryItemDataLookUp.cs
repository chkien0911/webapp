using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsRepositoryItemDataLookUp : IvsRepositoryItemLookUpEdit
    {
        #region Private Variables

        private string _currentLanguage = CommonData.StringEmpty;
        private bool _isActive = false;
        private bool _hasNull = false;
        private bool _isLeavePlanning = false;
        private bool _isLeaveReason = false;
        private bool _isFemale = false;
        private string _code = CommonData.StringEmpty;
        private string _EmpWrkType = CommonData.StringEmpty;

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Using to set option that display item have empty value or not
        /// </summary>
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                this._isActive = value;
            }
        }

        /// <summary>
        /// Using to set option that display item have empty value or not
        /// </summary>
        public bool HasNull
        {
            get
            {
                return _hasNull;
            }
            set
            {
                this._hasNull = value;
            }
        }

        public DataTable Table { get; set; }

        /// <summary>
        /// Using to set option that display item have empty value or not
        /// </summary>
        public bool IsLeavePlanning
        {
            get
            {
                return _isLeavePlanning;
            }
            set
            {
                this._isLeavePlanning = value;
            }
        }

        /// <summary>
        /// Using to set option that display item have empty value or not
        /// </summary>
        public bool IsFemale
        {
            get
            {
                return _isFemale;
            }
            set
            {
                this._isFemale = value;
            }
        }

        /// <summary>
        /// Using to set option that display item have empty value or not
        /// </summary>
        public bool IsLeaveReason
        {
            get
            {
                return _isLeaveReason;
            }
            set
            {
                this._isLeaveReason = value;
            }
        }

        /// <summary>
        /// Using to set option that display item have empty value or not
        /// </summary>
        public string EmpWrkType
        {
            get
            {
                return _EmpWrkType;
            }
            set
            {
                this._EmpWrkType = value;
            }
        }

        /// <summary>
        /// Presenting for FunctionId
        /// </summary>
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                this._code = value;

                if (!IsDesignMode)
                {
                    if (!string.IsNullOrEmpty(this._code))
                    {
                        this.FillData();
                        this.SetLanguage();
                        this._currentLanguage = UserSession.LangId;
                    }
                }
            }
        }

        #endregion Properties

        #region Public Method

        /// <summary>
        /// Load data of LookUpEdit follow to current language and keeping current selected index
        /// </summary>
        public void Reset()
        {
            if (((DataTable)this.DataSource) != null &&
                ((DataTable)this.DataSource).Rows.Count > 0
                && this._currentLanguage != UserSession.LangId)
            {
                this._currentLanguage = UserSession.LangId;
                this.SetLanguage();
            }
            this.ReloadData();
        }

        #endregion Public Method

        #region Private Method

        /// <summary>
        /// Get data from database and assign to datasource of LookUp
        /// </summary>
        protected override void FillData()
        {
            DataTable dtResult = new System.Data.DataTable();
            CommonBl commonBl = new CommonBl();
            commonBl.SelectDataForControl(this._code, out dtResult, IsActive);

            if (dtResult.Columns.Count > 0)
            {
                if (this.HasNull)
                {
                    dtResult.Rows.InsertAt(dtResult.NewRow(), 0);
                }
            }

            Table = dtResult;

            this.DataSource = dtResult;
            // this.EditValue = CommonData.StringEmpty;
            this.NullText = CommonData.StringEmpty;
        }

        /// <summary>
        /// Change content in control follow to current language
        /// </summary>
        protected virtual void SetLanguage()
        {
            this.Columns.Clear();

            //if (this.Code.Equals(CommonData.FunctionId.Msro00))
            // {
            //     IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
            //     this.Properties.Columns.Add(columnCode);
            //     this.Properties.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
            //     this.Properties.DisplayMember = CommonData.CommonCode;
            //     this.Properties.ValueMember = CommonData.CommonCode;
            // }
            // else if (this.Code.Equals(CommonData.FunctionId.Mssp00))
            // {
            //     IvsLookUpColumnInfo columnPeriod = new IvsLookUpColumnInfo(CommonKey.Period);
            //     this.Properties.Columns.Add(columnPeriod);
            //     this.Properties.Columns[CommonKey.Period].Caption = CommonData.StringEmpty;
            //     this.Properties.DisplayMember = CommonKey.Period;
            //     this.Properties.ValueMember = CommonKey.Period;
            // }

            // else if (this.Code.Equals(CommonData.FunctionId.Mswa00))
            // {
            //     IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
            //     IvsLookUpColumnInfo columnRemark = new IvsLookUpColumnInfo("Remark");
            //     this.Properties.Columns.Add(columnCode);
            //     this.Properties.Columns.Add(columnRemark);
            //     this.Properties.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
            //     this.Properties.Columns["Remark"].Caption = CommonData.StringEmpty;
            //     this.Properties.DisplayMember = "";
            //     this.Properties.ValueMember = CommonKey.Code;
            // }

            // else if (this.Code.Equals(CommonData.FunctionId.Hrem00))
            // {
            //     IvsLookUpColumnInfo columnEmployeeId = new IvsLookUpColumnInfo(CommonKey.EmployeeId);
            //     IvsLookUpColumnInfo columnEmployeeName = new IvsLookUpColumnInfo(CommonKey.EmployeeName);
            //     this.Properties.Columns.Add(columnEmployeeId);
            //     this.Properties.Columns.Add(columnEmployeeName);
            //     this.Properties.Columns[CommonKey.EmployeeId].Caption = CommonData.StringEmpty;
            //     this.Properties.Columns[CommonKey.EmployeeName].Caption = CommonData.StringEmpty;
            //     this.Properties.DisplayMember = "DisplayName";//CommonKey.EmployeeName;
            //     this.Properties.ValueMember = CommonKey.EmployeeId;
            // }

            //Start Le Hong Chau on 20130822
            //else if (this.Code.Equals(CommonData.FunctionId.Hrwe00))
            //{
            //    IvsLookUpColumnInfo columnEmployeeId = new IvsLookUpColumnInfo(CommonKey.EmployeeId);
            //    IvsLookUpColumnInfo columnEmployeeName = new IvsLookUpColumnInfo(CommonKey.EmployeeName);
            //    this.Properties.Columns.Add(columnEmployeeId);
            //    this.Properties.Columns.Add(columnEmployeeName);
            //    this.Properties.Columns[CommonKey.EmployeeId].Caption = CommonData.StringEmpty;
            //    this.Properties.Columns[CommonKey.EmployeeName].Caption = CommonData.StringEmpty;
            //    this.Properties.DisplayMember = "DisplayName";//CommonKey.EmployeeName;
            //    this.Properties.ValueMember = CommonKey.EmployeeId;
            //}
            //End Le Hong Chau on 20130822
            if (this.Code.Equals(CommonData.FunctionGr.MS_Units))
            {
                IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.Code);
                IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name);
                this.Columns.Add(columnCode);
                this.Columns.Add(columnName);
                this.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
                this.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                this.DisplayMember = CommonKey.Code;
                this.ValueMember = CommonKey.Code;
            }
            else
                if (this.Code.Equals(CommonData.FunctionGr.PR_SampleShippingText))
                {
                    IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.SampleShippingText);
                    this.Columns.Add(columnName);
                    this.Columns[CommonKey.SampleShippingText].Caption = CommonData.StringEmpty;
                    this.DisplayMember = CommonKey.SampleShippingText;
                    this.ValueMember = CommonKey.SampleShippingText;
                }
                else if (this.Code.Equals(CommonData.FunctionGr.MS_Employee))
                {
                    IvsLookUpColumnInfo columnEmployeeId = new IvsLookUpColumnInfo(CommonKey.Code);
                    IvsLookUpColumnInfo columnEmployeeName = new IvsLookUpColumnInfo(CommonKey.Name);
                    this.Columns.Add(columnEmployeeId);
                    this.Columns.Add(columnEmployeeName);
                    this.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
                    this.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                    this.DisplayMember = CommonKey.DisplayName;
                    this.ValueMember = CommonKey.Code;
                }
                else if (this.Code.Equals(CommonData.FunctionGr.MS_Customers))
                {
                    IvsLookUpColumnInfo columnCustomersCode = new IvsLookUpColumnInfo(CommonKey.Code);
                    IvsLookUpColumnInfo columnCustomersName = new IvsLookUpColumnInfo(CommonKey.Name);
                    this.Columns.Add(columnCustomersCode);
                    this.Columns.Add(columnCustomersName);
                    this.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
                    this.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                    this.DisplayMember = CommonKey.Name;
                    this.ValueMember = CommonKey.Code;
                }
                else if (this.Code.Equals(CommonData.FunctionGr.MS_Suppliers))
                {
                    IvsLookUpColumnInfo columnSuppliersCode = new IvsLookUpColumnInfo(CommonKey.Code);
                    IvsLookUpColumnInfo columnSuppliersName = new IvsLookUpColumnInfo(CommonKey.Name);
                    this.Columns.Add(columnSuppliersCode);
                    this.Columns.Add(columnSuppliersName);
                    this.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
                    this.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                    this.DisplayMember = CommonKey.Name;
                    this.ValueMember = CommonKey.Code;
                }
                else if (this.Code.Equals(CommonData.FunctionGr.MS_Items))
                {
                    IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.Code);
                    IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name);
                    IvsLookUpColumnInfo columnUnit = new IvsLookUpColumnInfo(CommonKey.InvUnitCode);
                    this.Columns.Add(columnCode);
                    this.Columns.Add(columnName);
                    this.Columns.Add(columnUnit);
                    this.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
                    this.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                    this.Columns[CommonKey.InvUnitCode].Caption = CommonData.StringEmpty;
                    this.DisplayMember = CommonKey.Code;
                    this.ValueMember = CommonKey.Code;
                }
                else if (this.Code.Equals(CommonData.FunctionGr.MS_Items_DisplayName))
                {
                    IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.Code);
                    IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name);
                    IvsLookUpColumnInfo columnUnit = new IvsLookUpColumnInfo(CommonKey.InvUnitCode);
                    this.Columns.Add(columnCode);
                    this.Columns.Add(columnName);
                    this.Columns.Add(columnUnit);
                    this.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
                    this.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                    this.Columns[CommonKey.InvUnitCode].Caption = CommonData.StringEmpty;
                    this.DisplayMember = CommonKey.Name;
                    this.ValueMember = CommonKey.Code;
                }
                else if (this.Code.Equals(CommonData.FunctionGr.SY_Functions))
                {
                    if (UserSession.LangId != null)
                    {
                        if (UserSession.LangId.Equals((CommonData.Language.VietNamese)))
                        {
                            IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.FunctionId);
                            IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name1);
                            this.Columns.Add(columnCode);
                            this.Columns.Add(columnName);
                            this.Columns[CommonKey.FunctionId].Caption = CommonData.StringEmpty;
                            this.Columns[CommonKey.Name1].Caption = CommonData.StringEmpty;
                            this.DisplayMember = CommonKey.Name1;
                            this.ValueMember = CommonKey.FunctionId;
                        }
                        else if (UserSession.LangId.Equals((CommonData.Language.English)))
                        {
                            IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.FunctionId);
                            IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name2);
                            this.Columns.Add(columnCode);
                            this.Columns.Add(columnName);
                            this.Columns[CommonKey.FunctionId].Caption = CommonData.StringEmpty;
                            this.Columns[CommonKey.Name2].Caption = CommonData.StringEmpty;
                            this.DisplayMember = CommonKey.Name2;
                            this.ValueMember = CommonKey.FunctionId;
                        }
                        else if (UserSession.LangId.Equals((CommonData.Language.Japanese)))
                        {
                            IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.FunctionId);
                            IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name3);
                            this.Columns.Add(columnCode);
                            this.Columns.Add(columnName);
                            this.Columns[CommonKey.FunctionId].Caption = CommonData.StringEmpty;
                            this.Columns[CommonKey.Name3].Caption = CommonData.StringEmpty;
                            this.DisplayMember = CommonKey.Name3;
                            this.ValueMember = CommonKey.FunctionId;
                        }
                    }
                    else
                    {
                        IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.FunctionId);
                        IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name2);
                        this.Columns.Add(columnCode);
                        this.Columns.Add(columnName);
                        this.Columns[CommonKey.FunctionId].Caption = CommonData.StringEmpty;
                        this.Columns[CommonKey.Name2].Caption = CommonData.StringEmpty;
                        this.DisplayMember = CommonKey.Name2;
                        this.ValueMember = CommonKey.FunctionId;
                    }
                }
                else if (this.Code.Equals(CommonData.FunctionGr.ST_StockTransactionMaster))
                {
                    IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.DocumentNumber);
                    this.Columns.Add(columnCode);
                    columnCode.Caption = CommonData.StringEmpty;
                    this.DisplayMember = CommonKey.DocumentNumber;
                    this.ValueMember = CommonKey.DocumentNumber;
                }
                else if (this.Code.Equals(CommonData.FunctionGr.ProcessType))
                {
                    IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.Name);
                    this.Columns.Add(columnCode);
                    columnCode.Caption = CommonData.StringEmpty;
                    this.DisplayMember = CommonKey.Name;
                    this.ValueMember = CommonKey.Code;
                }
                else
                {
                    if (UserSession.LangId == null)
                    {
                        IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
                        IvsLookUpColumnInfo columnName2 = new IvsLookUpColumnInfo(CommonKey.Name2);
                        this.Columns.Add(columnCode);
                        this.Columns.Add(columnName2);
                        this.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
                        this.Columns[CommonKey.Name2].Caption = CommonData.StringEmpty;
                        this.DisplayMember = CommonKey.Name2;
                        this.ValueMember = CommonData.CommonCode;
                    }
                    else
                    {
                        if (UserSession.LangId.Equals((CommonData.Language.VietNamese)))
                        {
                            IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
                            IvsLookUpColumnInfo columnName1 = new IvsLookUpColumnInfo(CommonKey.Name1);
                            this.Columns.Add(columnCode);
                            this.Columns.Add(columnName1);
                            this.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
                            this.Columns[CommonKey.Name1].Caption = CommonData.StringEmpty;
                            this.DisplayMember = CommonKey.Name1;
                            this.ValueMember = CommonData.CommonCode;
                        }
                        else if (UserSession.LangId.Equals((CommonData.Language.English)))
                        {
                            IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
                            IvsLookUpColumnInfo columnName2 = new IvsLookUpColumnInfo(CommonKey.Name2);
                            this.Columns.Add(columnCode);
                            this.Columns.Add(columnName2);
                            this.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
                            this.Columns[CommonKey.Name2].Caption = CommonData.StringEmpty;
                            this.DisplayMember = CommonKey.Name2;
                            this.ValueMember = CommonData.CommonCode;
                        }
                        else if (UserSession.LangId.Equals((CommonData.Language.Japanese)))
                        {
                            IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
                            IvsLookUpColumnInfo columnName3 = new IvsLookUpColumnInfo(CommonKey.Name3);
                            this.Columns.Add(columnCode);
                            this.Columns.Add(columnName3);
                            this.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
                            this.Columns[CommonKey.Name3].Caption = CommonData.StringEmpty;
                            this.DisplayMember = CommonKey.Name3;
                            this.ValueMember = CommonData.CommonCode;
                        }
                    }
                }
        }

        #endregion Private Method

    }
}