namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsTimeEdit : DevExpress.XtraEditors.TimeEdit
    {
        #region Pirvate Variables

        //An instance of error provider
        private IvsErrorProvider _errorProvider = new IvsErrorProvider();

        #endregion Pirvate Variables

        public IvsTimeEdit()
            : base()
        {
            this.Properties.Appearance.Options.UseTextOptions = true;
            this.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

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
    }
}