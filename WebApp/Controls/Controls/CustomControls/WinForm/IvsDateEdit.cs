using System.ComponentModel;
using Ivs.Core.Common;
using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsDateEdit : DevExpress.XtraEditors.DateEdit
    {
        #region Pirvate Variables

        //An instance of error provider
        private IvsErrorProvider _errorProvider = new IvsErrorProvider();

        private string _langID;

        #endregion Pirvate Variables

        #region Constructur

        public IvsDateEdit()
            : base()
        {
            this.Properties.NullDate = System.DateTime.MinValue;
            this.Properties.NullText = string.Empty;
            this.Properties.Appearance.Options.UseTextOptions = true;
            this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        #endregion Constructur

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

        //Defaut format date: "yyyy/MM/dd"
        private bool _isFormatDate = false;

        [Category("Type of text input"),
        Description("Type of text control"),
        DefaultValue(true)]
        public bool IsFormatDate
        {
            get
            {
                return this._isFormatDate;
            }
            set
            {
                if (value == true)
                {
                    this.Properties.DisplayFormat.FormatString = "yyyy/MM/dd";
                    this.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    this.Properties.EditFormat.FormatString = "yyyy/MM/dd";
                    this.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                    this.Properties.Mask.EditMask = "yyyy/MM/dd";
                    this.Properties.Mask.UseMaskAsDisplayFormat = true;
                }
                this._isFormatDate = value;
            }
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

        #region Setting Reset

        /// <summary>
        /// Setting Culture for display and store DateTime
        /// </summary>
        /// <param name="langID">
        /// Current Language
        /// </param>
        public void Reset(string langID)
        {
            _langID = langID;
            CultureInfo cultureInfo = new CultureInfo(_langID);
            this.Properties.DisplayFormat.FormatString = cultureInfo.ShortDateFormatPattern;
            this.Properties.EditFormat.FormatString = cultureInfo.ShortDateFormatPattern;
            this.Properties.Mask.EditMask = cultureInfo.ShortDateFormatPattern;
        }

        /// <summary>
        /// Setting Culture for display and store DateTime
        /// </summary>
        public override void Reset()
        {
            _langID = UserSession.LangId;
            CultureInfo cultureInfo = new CultureInfo();
            this.Properties.DisplayFormat.FormatString = cultureInfo.ShortDateFormatPattern;
            this.Properties.EditFormat.FormatString = cultureInfo.ShortDateFormatPattern;
            this.Properties.Mask.EditMask = cultureInfo.ShortDateFormatPattern;
        }

        /// <summary>
        /// Getting value following to DateTime format
        /// </summary>
        public string GetValue(string strFormat)
        {
            if (this.EditValue != null && !string.IsNullOrEmpty(this.EditValue.ToString()) && !this.EditValue.ToString().Equals(System.DateTime.MinValue.ToString()))
            {
                return System.DateTime.Parse(this.EditValue.ToString()).ToString(strFormat);
            }

            return CommonData.StringEmpty;
        }

        #endregion Setting Reset
    }
}