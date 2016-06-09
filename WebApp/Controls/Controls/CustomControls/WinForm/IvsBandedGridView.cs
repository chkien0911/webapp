namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsBandedGridView : DevExpress.XtraGrid.Views.BandedGrid.BandedGridView
    {
        public IvsBandedGridView(IvsGridControl ownerGrid):base(ownerGrid)
        {
            this.OptionsPrint.PrintHeader = false;
        }

        public IvsBandedGridView()
            : base()
        {
            
            this.OptionsPrint.PrintHeader = false;
        }

    }
}