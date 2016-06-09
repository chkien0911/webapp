using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.BLL.Common;
using System.Data;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsCheckedCodeLookup : CheckedComboBoxEdit
    {
        #region Private Variables

        private IvsErrorProvider _errorProvider = new IvsErrorProvider();
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
                        string editValue = CommonMethod.ParseString(this.EditValue);

                        this.FillData();

                        if (!CommonMethod.IsNullOrEmpty(editValue))
                        {
                            this.EditValue = editValue;
                        }

                        this._currentLanguage = UserSession.LangId;
                        this.RefreshEditValue();
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
        public virtual void SetError(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.User1);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        /// <summary>
        /// Set warning IvsMessage and icon for textbox control
        /// </summary>
        /// <param name="messageText">
        /// Content of message
        /// </param>
        public virtual void SetWarning(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        /// <summary>
        /// Set information IvsMessage and icon for textbox control
        /// </summary>
        /// <param name="messageText">
        /// Content of message
        /// </param>
        public virtual void SetInfo(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

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
            if (!string.IsNullOrEmpty(this.Code) && this._currentLanguage != UserSession.LangId)
            {
                string selectedValue = CommonMethod.ParseString(this.EditValue);// this.EditValue == null ? string.Empty : this.EditValue.ToString();
                this.FillData();
                this.EditValue = selectedValue;
                this._currentLanguage = UserSession.LangId;
                this.RefreshEditValue();
            }
        }

        #endregion Public Method

        #region Private Method

        /// <summary>
        /// Get data from database and assign to datasource of LookUp
        /// </summary>
        private void FillData()
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
                    DataRow newRow = dtResult.NewRow();
                    //newRow[0] = CommonData.StringEmpty;
                    dtResult.Rows.InsertAt(newRow, 0);
                }
            }

            this.Properties.DataSource = dtResult;
            this.Properties.DisplayMember = CommonData.CommonValue;
            this.Properties.ValueMember = CommonData.CommonKey;
            this.EditValue = CommonData.StringEmpty;
            this.Properties.NullText = CommonData.StringEmpty;
        }

        #endregion Private Method
    }
}
