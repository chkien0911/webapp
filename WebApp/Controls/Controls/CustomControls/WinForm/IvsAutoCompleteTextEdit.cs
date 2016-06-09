using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Data;
using Ivs.Core.Common;
using System.Windows.Forms;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsAutoCompleteTextEdit : TextBox
    {

        #region Pirvate Variables

        //An instance of error provider
        private IvsErrorProvider _errorProvider = new IvsErrorProvider();
        DataTable dtResult = new DataTable();
        private string _currentLanguage = CommonData.StringEmpty;
        private bool _isActive = false;
        private string _code = CommonData.StringEmpty;

        #endregion Pirvate Variables

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

                if (!string.IsNullOrEmpty(this._code))
                {
                    this.FillData();
                    this.SetLanguage();
                    this._currentLanguage = UserSession.LangId;
                }
            }
        }

        #endregion Properties

        #region override property

        public override string Text
        {
            get
            {
                return base.Text.Trim();
            }
            set
            {
                base.Text = value;
            }
        }

        #endregion override property

        #region Methods About Setting Message

        /// <summary>
        /// Set error IvsMessage and icon for textbox control
        /// </summary>
        /// <param name="messageText">
        /// Content of message
        /// </param>
        public void SetError(string messageText)
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
        public void SetWarning(string messageText)
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
        public void SetInfo(string messageText)
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

        #region Public Methods

        /// <summary>
        /// Load data of LookUpEdit follow to current language and keeping current selected index
        /// </summary>
        public void Reset()
        {
            if (this.dtResult.Rows.Count > 0 && this._currentLanguage != UserSession.LangId)
            {
                this.SetLanguage();
                this._currentLanguage = UserSession.LangId;
            }
        }

        #endregion Public Method

        #region Protected Method

        /// <summary>
        /// Get data from database and assign to datasource of LookUp
        /// </summary>
        protected virtual void FillData()
        {
            //Select data
            CommonBl commonBl = new CommonBl();
            commonBl.SelectDataForControl(this._code, out dtResult);
        }

        /// <summary>
        /// Change content in control follow to current language
        /// </summary>
        protected virtual void SetLanguage()
        {
            AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();

            //Set datasource for table that not using multilanguage data
            if (this.Code.Equals(CommonData.FunctionGr.MS_Units))
            {
                foreach (DataRow row in this.dtResult.Rows)
                {
                    customSource.Add(CommonMethod.ParseString(row[CommonKey.Name]));
                }

                this.AutoCompleteSource = AutoCompleteSource.CustomSource;
                this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.AutoCompleteCustomSource = customSource;
            }
            //Set datasource for table that using multilanguage data
            else
            {
                if (UserSession.LangId == null)
                {
                    foreach (DataRow row in this.dtResult.Rows)
                    {
                        customSource.Add(CommonMethod.ParseString(row[CommonKey.Name2]));
                    }

                    this.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    this.AutoCompleteCustomSource = customSource;
                }
                else
                {
                    if (UserSession.LangId.Equals(CommonData.Language.VietNamese))
                    {
                        foreach (DataRow row in this.dtResult.Rows)
                        {
                            customSource.Add(CommonMethod.ParseString(row[CommonKey.Name1]));
                        }

                        this.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        this.AutoCompleteCustomSource = customSource;
                    }
                    else if (UserSession.LangId.Equals(CommonData.Language.English))
                    {
                        foreach (DataRow row in this.dtResult.Rows)
                        {
                            customSource.Add(CommonMethod.ParseString(row[CommonKey.Name2]));
                        }

                        this.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        this.AutoCompleteCustomSource = customSource;
                    }
                    else
                    {
                        foreach (DataRow row in this.dtResult.Rows)
                        {
                            customSource.Add(CommonMethod.ParseString(row[CommonKey.Name3]));
                        }

                        this.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        this.AutoCompleteCustomSource = customSource;
                    }
                }
            }
        }

        #endregion Private Method
    }
}
