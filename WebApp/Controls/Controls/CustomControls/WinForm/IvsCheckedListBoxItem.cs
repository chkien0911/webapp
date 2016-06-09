namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsCheckedListBoxItem : DevExpress.XtraEditors.Controls.CheckedListBoxItem
    {
        public IvsCheckedListBoxItem()
        {
        }

        public IvsCheckedListBoxItem(object value, string description, System.Windows.Forms.CheckState checkState, bool enabled, string name)
            : base(value, description, checkState, enabled)
        {
            _name = name;
        }

        private string _name = string.Empty;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}