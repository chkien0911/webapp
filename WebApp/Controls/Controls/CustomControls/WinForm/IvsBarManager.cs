using System.ComponentModel;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsBarManager : DevExpress.XtraBars.BarManager
    {
        public IvsBarManager()
        {
        }

        public IvsBarManager(IContainer container)
        {
            new DevExpress.XtraBars.BarManager(container);
        }
    }
}