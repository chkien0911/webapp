using System.ComponentModel;
using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsDataLookUp : IvsLookUpEdit1
    {
        #region Private Variables

        //private IvsErrorProvider _errorProvider = new IvsErrorProvider();
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

        private int _selectedIndex = -1;

        [DefaultValue(-1)]
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                if (value >= 0)
                {
                    DataTable dtSource = ((DataTable)this.Properties.DataSource);
                    if ((dtSource != null && dtSource.Rows.Count > 0))
                    {
                        this.EditValue = dtSource.Rows[_selectedIndex][this.Properties.ValueMember];
                    }
                    else
                    {
                        this.EditValue = CommonData.StringEmpty;
                    }
                }
                //else
                //{
                //    //this.EditValue = CommonData.StringEmpty;
                //}
            }
        }

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
                        string editValue = CommonMethod.ParseString(this.EditValue);
                        this.FillData();
                        this.SetLanguage();

                        if (!CommonMethod.IsNullOrEmpty(editValue))
                        {
                            this.EditValue = editValue;
                        }
                        else
                        {
                            this.SelectedIndex = _selectedIndex;
                        }

                        this._currentLanguage = UserSession.LangId;
                    }
                }
            }
        }

        #endregion Properties

        #region Public Method

        #region Methods About Setting Message

        /// <summary>
        /// Set error IvsMessage and icon for textbox control
        /// </summary>
        /// <param name="messageText">
        /// Content of message
        /// </param>
        //public override void SetError(string messageText)
        //{
        //    _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.User1);
        //    _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        //}

        ///// <summary>
        ///// Set warning IvsMessage and icon for textbox control
        ///// </summary>
        ///// <param name="messageText">
        ///// Content of message
        ///// </param>
        //public override void SetWarning(string messageText)
        //{
        //    _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
        //    _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        //}

        ///// <summary>
        ///// Set information IvsMessage and icon for textbox control
        ///// </summary>
        ///// <param name="messageText">
        ///// Content of message
        ///// </param>
        //public override void SetInfo(string messageText)
        //{
        //    _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
        //    _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        //}

        #endregion Methods About Setting Message

        #region Methods About Clearing Message

        /// <summary>
        ///Clear error IvsMessage and icon for textbox control
        /// </summary>
        public void ClearErrors()
        {
            if (_errorProvider.HasErrors)
            {
                _errorProvider.ClearErrors();
            }
        }

        #endregion Methods About Clearing Message

        /// <summary>
        /// Load data of LookUpEdit follow to current language and keeping current selected index
        /// </summary>
        public override void Reset()
        {
            if (((DataTable)this.Properties.DataSource) != null &&
                ((DataTable)this.Properties.DataSource).Rows.Count > 0
                && this._currentLanguage != UserSession.LangId)
            {
                string selectedValue = CommonMethod.ParseString(this.EditValue);// this.EditValue == null ? string.Empty : this.EditValue.ToString();
                this.SetLanguage();
                this.EditValue = selectedValue;
                if (CommonMethod.IsNullOrEmpty(selectedValue))
                {
                    this.SelectedIndex = _selectedIndex;
                }
                this._currentLanguage = UserSession.LangId;
            }
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
            commonBl.SelectDataForControl(this._code, out dtResult);

            #region Old

            //switch (_code)
            //{
            //#region Function of Master

            //case CommonData.FunctionId.Msaa00:
            //    Msaa00LookUpDao msaa00LookUpDao = new Msaa00LookUpDao();
            //    msaa00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msae00:
            //    Msae00LookUpDao msae00LookUpDao = new Msae00LookUpDao();
            //    msae00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msal00:
            //    Msal00LookUpDao msal00LookUpDao = new Msal00LookUpDao();
            //    msal00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msap00:
            //    Msap00LookUpDao msap00LookUpDao = new Msap00LookUpDao();
            //    msap00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msar00:
            //    Msar00LookUpDao msar00LookUpDao = new Msar00LookUpDao();
            //    msar00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            ////case CommonData.FunctionId.Msca00:
            ////    Msca00LookUpDao msca00LookUpDao = new Msca00LookUpDao();
            ////    msca00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            ////    break;

            //case CommonData.FunctionId.Mscr00:
            //    Mscr00LookUpDao mscr00LookUpDao = new Mscr00LookUpDao();
            //    mscr00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msdd00:
            //    Msdd00LookUpDao msdd00LookUpDao = new Msdd00LookUpDao();
            //    msdd00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msde00:
            //    Msde00LookUpDao msde00LookUpDao = new Msde00LookUpDao();
            //    msde00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msdo00:
            //    Msdo00LookUpDao msdo00LookUpDao = new Msdo00LookUpDao();
            //    msdo00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msle00:
            //    Msle00LookUpDao msle00LookUpDao = new Msle00LookUpDao();
            //    msle00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msfm00:
            //    Msfm00LookUpDao msfm00LookUpDao = new Msfm00LookUpDao();
            //    msfm00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Mshp00:
            //    Mshp00LookUpDao mshp00LookUpDao = new Mshp00LookUpDao();
            //    mshp00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msir00:
            //    Msir00LookUpDao msir00LookUpDao = new Msir00LookUpDao();
            //    msir00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msit00:
            //    Msit00LookUpDao msit00LookUpDao = new Msit00LookUpDao();
            //    msit00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Mslc00:
            //    Mslc00LookUpDao mslc00LookUpDao = new Mslc00LookUpDao();
            //    mslc00LookUpDao.SelectCbb(this.IsActive, this.IsLeavePlanning,out dtResult);
            //    break;

            //case CommonData.FunctionId.Msof00:
            //    Msof00LookUpDao msof00LookUpDao = new Msof00LookUpDao();
            //    msof00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msop00:
            //    Msop00LookUpDao msop00LookUpDao = new Msop00LookUpDao();
            //    msop00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Mspo00:
            //    Mspo00LookUpDao mspo00LookUpDao = new Mspo00LookUpDao();
            //    mspo00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Mspr00:
            //    Mspr00LookUpDao mspr00LookUpDao = new Mspr00LookUpDao();
            //    mspr00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msre00:
            //    Msre00LookUpDao msre00LookUpDao = new Msre00LookUpDao();
            //    msre00LookUpDao.SelectCbb(this.IsActive, this.IsLeaveReason, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msro00:
            //    Msro00LookUpDao msro00LookUpDao = new Msro00LookUpDao();
            //    msro00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            ////case CommonData.FunctionId.Msrs00:
            ////    Msrs00LookUpDao msrs00LookUpDao = new Msrs00LookUpDao();
            ////    msrs00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            ////    break;

            //case CommonData.FunctionId.Msrt00:
            //    Msrt00LookUpDao msrt00LookUpDao = new Msrt00LookUpDao();
            //    msrt00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msse00:
            //    Msse00LookUpDao msse00LookUpDao = new Msse00LookUpDao();
            //    msse00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Mssh00:
            //    Mssh00LookUpDao mssh00LookUpDao = new Mssh00LookUpDao();
            //    mssh00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Mssk00:
            //    Mssk00LookUpDao mssk00LookUpDao = new Mssk00LookUpDao();
            //    mssk00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Mssp00:
            //    Mssp00LookUpDao mssp00LookUpDao = new Mssp00LookUpDao();
            //    mssp00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Mste00:
            //    Mste00LookUpDao mste00LookUpDao = new Mste00LookUpDao();
            //    mste00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msug00:
            //    Msug00LookUpDao msug00LookUpDao = new Msug00LookUpDao();
            //    msug00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msur00:
            //    Msur00LookUpDao msur00LookUpDao = new Msur00LookUpDao();
            //    msur00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            //case CommonData.FunctionId.Msbr00:
            //    Msbr00LookUpDao msbr00LookUpDao = new Msbr00LookUpDao();
            //    msbr00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;
            //case CommonData.FunctionId.Mswa00:
            //    Mswa00LookUpDao mswa00LookUpDao = new Mswa00LookUpDao();
            //    mswa00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;
            //#endregion

            //#region Function of Human Resource

            //case CommonData.FunctionId.Hrem00:
            //    Hrem00LookUpDao hrem00LookUpDao = new Hrem00LookUpDao();
            //    hrem00LookUpDao.SelectCbb(this.IsActive, this.IsFemale, this.EmpWrkType, out dtResult);
            //    //this.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            //    //this.Properties.AutoSearchColumnIndex = 0;
            //    break;

            //case CommonData.FunctionId.Hrlp00:
            //    Hrlp00LookUpDao hrlp00LookUpDao = new Hrlp00LookUpDao();
            //    hrlp00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;

            ////Start Le Hong Chau on 20130822
            //case CommonData.FunctionId.Hrwe00:
            //    Hrwe00LookupDao hrwe00LookUpDao = new Hrwe00LookupDao();
            //    hrwe00LookUpDao.SelectCbb(this.IsActive, out dtResult);
            //    break;
            ////End Le Hong Chau on 20130822

            //#endregion

            //#region Function of sy_functions table

            //case CommonData.FunctionId.Syfunctions:
            //    FunctionsDao functionsDao = new FunctionsDao();
            //    System.Collections.Hashtable htCondition = new System.Collections.Hashtable();
            //    functionsDao.SelectData(htCondition, out dtResult);
            //    break;

            //#endregion
            //}

            #endregion Old

            if (this.HasNull && dtResult.Columns.Count > 0)
            {
                DataRow newRow = dtResult.NewRow();
                //newRow[0] = CommonData.StringEmpty;
                dtResult.Rows.InsertAt(newRow, 0);
            }

            this.Properties.DataSource = dtResult;
            this.EditValue = CommonData.StringEmpty;
            this.Properties.NullText = CommonData.StringEmpty;
        }

        /// <summary>
        /// Change content in control follow to current language
        /// </summary>
        protected virtual void SetLanguage()
        {
            this.Properties.Columns.Clear();

            if (this.Code.Equals(CommonData.FunctionGr.MS_Units))
            {
                IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.Code);
                IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name);
                this.Properties.Columns.Add(columnCode);
                this.Properties.Columns.Add(columnName);
                this.Properties.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
                this.Properties.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                this.Properties.DisplayMember = CommonKey.Code;
                this.Properties.ValueMember = CommonKey.Code;
            }
            else if (this.Code.Equals(CommonData.FunctionGr.MS_Currency))
            {
                IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.Code);
                IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name);
                this.Properties.Columns.Add(columnCode);
                this.Properties.Columns.Add(columnName);
                this.Properties.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
                this.Properties.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                this.Properties.DisplayMember = CommonKey.Name;
                this.Properties.ValueMember = CommonData.CommonCode;
            }
            else if (this.Code.Equals(CommonData.FunctionGr.MS_Employee))
            {
                IvsLookUpColumnInfo columnEmployeeId = new IvsLookUpColumnInfo(CommonKey.Code);
                IvsLookUpColumnInfo columnEmployeeName = new IvsLookUpColumnInfo(CommonKey.Name);
                this.Properties.Columns.Add(columnEmployeeId);
                this.Properties.Columns.Add(columnEmployeeName);
                this.Properties.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
                this.Properties.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                this.Properties.DisplayMember = CommonKey.DisplayName;
                this.Properties.ValueMember = CommonKey.Code;
            }
            else if (this.Code.Equals(CommonData.FunctionGr.MS_Customers))
            {
                IvsLookUpColumnInfo columnCustomersCode = new IvsLookUpColumnInfo(CommonKey.Code);
                IvsLookUpColumnInfo columnCustomersName = new IvsLookUpColumnInfo(CommonKey.Name);
                this.Properties.Columns.Add(columnCustomersCode);
                this.Properties.Columns.Add(columnCustomersName);
                this.Properties.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
                this.Properties.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                this.Properties.DisplayMember = CommonKey.Name;
                this.Properties.ValueMember = CommonKey.Code;
            }
            else if (this.Code.Equals(CommonData.FunctionGr.MS_Suppliers))
            {
                IvsLookUpColumnInfo columnSuppliersCode = new IvsLookUpColumnInfo(CommonKey.Code);
                IvsLookUpColumnInfo columnSuppliersName = new IvsLookUpColumnInfo(CommonKey.Name);
                this.Properties.Columns.Add(columnSuppliersCode);
                this.Properties.Columns.Add(columnSuppliersName);
                this.Properties.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
                this.Properties.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                this.Properties.DisplayMember = CommonKey.Name;
                this.Properties.ValueMember = CommonKey.Code;
            }
            else if (this.Code.Equals(CommonData.FunctionGr.ST_StockOverview)
                    || this.Code.Equals(CommonData.FunctionGr.ST_StockTransactionMaster))
            {
                IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.DocumentNumber);
                //IvsLookUpColumnInfo columnPeriodName = new IvsLookUpColumnInfo(CommonKey.Period);
                this.Properties.Columns.Add(columnCode);
                //this.Properties.Columns.Add(columnPeriodName);
                this.Properties.Columns[CommonKey.DocumentNumber].Caption = CommonData.StringEmpty;
                //this.Properties.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                this.Properties.DisplayMember = CommonKey.DocumentNumber;
                this.Properties.ValueMember = CommonKey.DocumentNumber;
            }
            else if (this.Code.Equals(CommonData.FunctionGr.ST_MonthlyProcess))
            {
                IvsLookUpColumnInfo columnPeriodCode = new IvsLookUpColumnInfo(CommonKey.Period);
                //IvsLookUpColumnInfo columnPeriodName = new IvsLookUpColumnInfo(CommonKey.Period);
                this.Properties.Columns.Add(columnPeriodCode);
                //this.Properties.Columns.Add(columnPeriodName);
                this.Properties.Columns[CommonKey.Period].Caption = CommonData.StringEmpty;
                //this.Properties.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                this.Properties.DisplayMember = CommonKey.Period;
                this.Properties.ValueMember = CommonKey.Period;
            }
            else if (this.Code.Equals(CommonData.FunctionGr.ST_MonthlyProcess_PeriodClose))
            {
                IvsLookUpColumnInfo columnPeriodCode = new IvsLookUpColumnInfo(CommonKey.Period);
                //IvsLookUpColumnInfo columnPeriodName = new IvsLookUpColumnInfo(CommonKey.Period);
                this.Properties.Columns.Add(columnPeriodCode);
                //this.Properties.Columns.Add(columnPeriodName);
                this.Properties.Columns[CommonKey.Period].Caption = CommonData.StringEmpty;
                //this.Properties.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
                this.Properties.DisplayMember = CommonKey.Period;
                this.Properties.ValueMember = CommonKey.Period;
            }
            else if (this.Code.Equals(CommonData.FunctionGr.INV_Invoice))
            {
                IvsLookUpColumnInfo invNo = new IvsLookUpColumnInfo(CommonKey.InvNo);
                this.Properties.Columns.Add(invNo);
                this.Properties.Columns[CommonKey.InvNo].Caption = CommonData.StringEmpty;
                this.Properties.DisplayMember = CommonKey.InvNo;
                this.Properties.ValueMember = CommonKey.InvNo;
            }
            //else if (this.Code.Equals(CommonData.FunctionGr.MS_Items))
            //{
            //    IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.Code);
            //    IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name);
            //    IvsLookUpColumnInfo columnUnit = new IvsLookUpColumnInfo(CommonKey.InvUnitCode);
            //    this.Properties.Columns.Add(columnCode);
            //    this.Properties.Columns.Add(columnName);
            //    this.Properties.Columns.Add(columnUnit);
            //    this.Properties.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
            //    this.Properties.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
            //    this.Properties.Columns[CommonKey.InvUnitCode].Caption = CommonData.StringEmpty;
            //    this.Properties.DisplayMember = CommonKey.DisplayName;
            //    this.Properties.ValueMember = CommonKey.Code;
            //}
            else if (this.Code.Equals(CommonData.FunctionGr.SY_Functions))
            {
                if (UserSession.LangId != null)
                {
                    if (UserSession.LangId.Equals((CommonData.Language.VietNamese)))
                    {
                        IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.FunctionId);
                        IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name1);
                        this.Properties.Columns.Add(columnCode);
                        this.Properties.Columns.Add(columnName);
                        this.Properties.Columns[CommonKey.FunctionId].Caption = CommonData.StringEmpty;
                        this.Properties.Columns[CommonKey.Name1].Caption = CommonData.StringEmpty;
                        this.Properties.DisplayMember = CommonKey.Name1;
                        this.Properties.ValueMember = CommonKey.FunctionId;
                    }
                    else if (UserSession.LangId.Equals((CommonData.Language.English)))
                    {
                        IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.FunctionId);
                        IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name2);
                        this.Properties.Columns.Add(columnCode);
                        this.Properties.Columns.Add(columnName);
                        this.Properties.Columns[CommonKey.FunctionId].Caption = CommonData.StringEmpty;
                        this.Properties.Columns[CommonKey.Name2].Caption = CommonData.StringEmpty;
                        this.Properties.DisplayMember = CommonKey.Name2;
                        this.Properties.ValueMember = CommonKey.FunctionId;
                    }
                    else if (UserSession.LangId.Equals((CommonData.Language.Japanese)))
                    {
                        IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.FunctionId);
                        IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name3);
                        this.Properties.Columns.Add(columnCode);
                        this.Properties.Columns.Add(columnName);
                        this.Properties.Columns[CommonKey.FunctionId].Caption = CommonData.StringEmpty;
                        this.Properties.Columns[CommonKey.Name3].Caption = CommonData.StringEmpty;
                        this.Properties.DisplayMember = CommonKey.Name3;
                        this.Properties.ValueMember = CommonKey.FunctionId;
                    }
                }
                else
                {
                    IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.FunctionId);
                    IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name2);
                    this.Properties.Columns.Add(columnCode);
                    this.Properties.Columns.Add(columnName);
                    this.Properties.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
                    this.Properties.Columns[CommonKey.Name2].Caption = CommonData.StringEmpty;
                    this.Properties.DisplayMember = CommonKey.Name2;
                    this.Properties.ValueMember = CommonKey.Code;
                }
            }
            else if (this.Code.Equals(CommonData.FunctionGr.CurrentPeriod_Document))
            {
                IvsLookUpColumnInfo documentNumber = new IvsLookUpColumnInfo(CommonKey.DocumentNumber);
                this.Properties.Columns.Add(documentNumber);
                this.Properties.Columns[CommonKey.DocumentNumber].Caption = CommonData.StringEmpty;
                this.Properties.DisplayMember = CommonKey.DocumentNumber;
                this.Properties.ValueMember = CommonKey.DocumentNumber;
            }
            else
            {
                if (UserSession.LangId == null)
                {
                    IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
                    IvsLookUpColumnInfo columnName2 = new IvsLookUpColumnInfo(CommonKey.Name2);
                    this.Properties.Columns.Add(columnCode);
                    this.Properties.Columns.Add(columnName2);
                    this.Properties.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
                    this.Properties.Columns[CommonKey.Name2].Caption = CommonData.StringEmpty;
                    this.Properties.DisplayMember = CommonKey.Name2;
                    this.Properties.ValueMember = CommonData.CommonCode;
                }
                else
                {
                    if (UserSession.LangId.Equals((CommonData.Language.VietNamese)))
                    {
                        IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
                        IvsLookUpColumnInfo columnName1 = new IvsLookUpColumnInfo(CommonKey.Name1);
                        this.Properties.Columns.Add(columnCode);
                        this.Properties.Columns.Add(columnName1);
                        this.Properties.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
                        this.Properties.Columns[CommonKey.Name1].Caption = CommonData.StringEmpty;
                        this.Properties.DisplayMember = CommonKey.Name1;
                        this.Properties.ValueMember = CommonData.CommonCode;
                    }
                    else if (UserSession.LangId.Equals((CommonData.Language.English)))
                    {
                        IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
                        IvsLookUpColumnInfo columnName2 = new IvsLookUpColumnInfo(CommonKey.Name2);
                        this.Properties.Columns.Add(columnCode);
                        this.Properties.Columns.Add(columnName2);
                        this.Properties.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
                        this.Properties.Columns[CommonKey.Name2].Caption = CommonData.StringEmpty;
                        this.Properties.DisplayMember = CommonKey.Name2;
                        this.Properties.ValueMember = CommonData.CommonCode;
                    }
                    else if (UserSession.LangId.Equals((CommonData.Language.Japanese)))
                    {
                        IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
                        IvsLookUpColumnInfo columnName3 = new IvsLookUpColumnInfo(CommonKey.Name3);
                        this.Properties.Columns.Add(columnCode);
                        this.Properties.Columns.Add(columnName3);
                        this.Properties.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
                        this.Properties.Columns[CommonKey.Name3].Caption = CommonData.StringEmpty;
                        this.Properties.DisplayMember = CommonKey.Name3;
                        this.Properties.ValueMember = CommonData.CommonCode;
                    }
                }
            }
        }

        #endregion Private Method
    }
}