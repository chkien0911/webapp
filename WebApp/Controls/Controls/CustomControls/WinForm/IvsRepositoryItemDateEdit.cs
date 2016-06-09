using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsRepositoryItemDateEdit : DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    {
        private string _langID;

        public IvsRepositoryItemDateEdit()
            : base()
        {
            this.NullDate = System.DateTime.MinValue;
            this.NullText = string.Empty;
        }

        /// <summary>
        /// Setting Culture for display and store DateTime
        /// </summary>
        public void Reset()
        {
            _langID = UserSession.LangId;
            CultureInfo cultureInfo = new CultureInfo();
            this.Properties.Mask.EditMask = cultureInfo.ShortDateFormatPattern;
        }
    }
}