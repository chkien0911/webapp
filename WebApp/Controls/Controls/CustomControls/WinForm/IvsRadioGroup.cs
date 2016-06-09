namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsRadioGroup : DevExpress.XtraEditors.RadioGroup
    {
        private IvsErrorProvider _errorProvider = new IvsErrorProvider();

        public void SetError(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.User1);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }
    }
}