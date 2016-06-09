using System.ComponentModel;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsDockManager : DevExpress.XtraBars.Docking.DockManager
    {
        public IvsDockManager()
        {
        }

        public IvsDockManager(IContainer container)
        {
            new DevExpress.XtraBars.Docking.DockManager(container);
        }

        #region Properties

        public bool AllowResize { get; set; }

        private bool _isAutoHide = true;

        [DefaultValue(true)]
        public bool IsAutoHide
        {
            get
            {
                return _isAutoHide;
            }
            set
            {
                _isAutoHide = value;
            }
        }

        #endregion Properties
    }
}