using System.ComponentModel;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsPrintBarManager : DevExpress.XtraPrinting.Preview.PrintBarManager
    {
        public IvsPrintBarManager()
        {
        }

        public IvsPrintBarManager(IContainer container)
        {
            new DevExpress.XtraPrinting.Preview.PrintBarManager(container);
        }
    }
}