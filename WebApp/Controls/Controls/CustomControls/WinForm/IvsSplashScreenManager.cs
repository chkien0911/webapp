using DevExpress.XtraEditors;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsSplashScreenManager : DevExpress.XtraSplashScreen.SplashScreenManager
    {
        public static void ShowProgressBar(XtraForm form)
        {
            try
            {
                CloseForm(false);
                ShowForm(form, typeof(Ivs.Controls.Forms.ProgressBarForm), true, false, false);
            }
            catch 
            { }
        }

        public static void HideProgressBar()
        {
            CloseForm(false);
        }
    }
}