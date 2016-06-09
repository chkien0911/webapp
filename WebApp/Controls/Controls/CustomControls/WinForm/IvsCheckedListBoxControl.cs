/* =========================================
 * Author:      NNHieu
 * Create Date: 2012/09/11
 * Reviser: NHKhuong
 * Revise Date: 2012/09/14
 ========================================= */

using System.Collections.Generic;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsCheckedListBoxControl : DevExpress.XtraEditors.CheckedListBoxControl
    {
        #region Private Variables

        private string _currentLanguage = CommonData.StringEmpty;
        private string _code = CommonData.StringEmpty;
        private IvsErrorProvider _errorProvider = new IvsErrorProvider();

        #endregion Private Variables

        #region Properties

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
            if (this.ItemCount > 0 && this._currentLanguage != UserSession.LangId)
            {
                List<string> listChecked = new List<string>();

                for (int i = 0; i < this.CheckedItems.Count; i++)
                {
                    listChecked.Add(this.CheckedItems[i].ToString());
                }

                this.SetLanguage();

                for (int j = 0; j < listChecked.Count; j++)
                {
                    for (int k = 0; k < this.ItemCount; k++)
                    {
                        if (listChecked[j].ToString() == this.GetItemValue(k).ToString())
                        {
                            this.SetItemChecked(k, true);
                            break;
                        }
                    }
                }

                this._currentLanguage = UserSession.LangId;
            }
        }

        #endregion Public Method

        #region Private Method

        /// <summary>
        /// Get data from database and assign to datasource of LookUp
        /// </summary>
        private void FillData()
        {
            //System.Data.DataTable dtResult = new System.Data.DataTable();
            System.Data.DataTable dtResult = new System.Data.DataTable();
            CommonBl commonBl = new CommonBl();
            //get data list by Code
            commonBl.SelectDataForControl(this._code, out dtResult);

            this.DataSource = dtResult;
        }

        /// <summary>
        /// Change content in control follow to current language
        /// </summary>
        private void SetLanguage()
        {
            if (UserSession.LangId.Equals((CommonData.Language.VietNamese)))
            {
                this.DisplayMember = "Name1";
                this.ValueMember = CommonData.CommonCode;
            }
            else if (UserSession.LangId.Equals((CommonData.Language.English)))
            {
                this.DisplayMember = "Name2";
                this.ValueMember = CommonData.CommonCode;
            }
            else if (UserSession.LangId.Equals((CommonData.Language.Japanese)))
            {
                this.DisplayMember = "Name3";
                this.ValueMember = CommonData.CommonCode;
            }
        }

        #endregion Private Method

        /// <summary>
        /// Set error IvsMessage and icon for textbox control
        /// </summary>
        /// <param name="messageText">
        /// Content of message
        /// </param>
        public void SetError(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.User1);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.TopRight);
        }
    }
}