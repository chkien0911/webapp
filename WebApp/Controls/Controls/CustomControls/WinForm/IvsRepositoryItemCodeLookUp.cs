using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsRepositoryItemCodeLookUp : IvsRepositoryItemLookUpEdit
    {
        #region Private Variables

        private string _currentLanguage = CommonData.StringEmpty;
        private bool _hasNull = false;
        private string _code = CommonData.StringEmpty;

        #endregion Private Variables

        #region Properties

        /// <summary>
        /// Using to set option that display item have empty value or not
        /// </summary>
        public bool HasNull
        {
            get
            {
                return this._hasNull;
            }
            set
            {
                this._hasNull = value;
            }
        }

        /// <summary>
        /// Presenting for code of common data
        /// </summary>
        public string Code
        {
            get
            {
                return this._code;
            }
            set
            {
                this._code = value;

                if (!IsDesignMode)
                {
                    if (!string.IsNullOrEmpty(this._code))
                    {
                        this.FillData();
                        this._currentLanguage = UserSession.LangId == null ? CommonData.Language.English : UserSession.LangId;
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
            if (((DataTable)this.DataSource) != null
                && ((DataTable)this.DataSource).Rows.Count > 0
                && this._currentLanguage != UserSession.LangId)
            {
                this._currentLanguage = UserSession.LangId;
                this.ReloadData();
            }
        }

        #endregion Public Method

        #region Private Method

        /// <summary>
        /// Get data from database and assign to datasource of LookUp
        /// </summary>
        protected override void FillData()
        {
            System.Data.DataTable dtResult = new System.Data.DataTable();
            System.Collections.Hashtable htCond = new System.Collections.Hashtable();
            htCond.Add(CommonData.CommonCode, Code);
            CommonBl commonBl = new CommonBl();
            commonBl.SelectCommonData(htCond, out dtResult);

            if (dtResult.Columns.Count > 0)
            {
                if (HasNull)
                {
                    dtResult.Rows.InsertAt(dtResult.NewRow(), 0);
                }
            }

            this.DataSource = dtResult;
            this.Columns.Clear();
            IvsLookUpColumnInfo lookupColumn = new IvsLookUpColumnInfo(CommonData.CommonValue);
            this.Columns.Add(lookupColumn);
            this.Columns[CommonData.CommonValue].Caption = CommonData.StringEmpty;
            this.DisplayMember = CommonData.CommonValue;
            this.ValueMember = CommonData.CommonKey;
            this.NullText = CommonData.StringEmpty;
            if (this.DropDownRows > dtResult.Rows.Count) this.DropDownRows = dtResult.Rows.Count + 1;
        }

        #endregion Private Method
    }
}