using System;
using System.Resources;
using System.Threading;

namespace Ivs.Resources.Common
{
    public class I18n
    {
        //private static System.Globalization.CultureInfo currentInfo = Thread.CurrentThread.CurrentUICulture;
        private static ResourceManager resxManager = new ResourceManager("Ivs.Resources.Resource.Res", typeof(I18n).Assembly);
        //private static string functionID;

        public I18n(string functionID)
        {
            functionID = functionID + "Form";
            //resxManager = new ResourceManager("Ivs.Resources.Resource.Res", typeof(I18n).Assembly);
            //GetScreenDisplayResource();
        }

        public I18n()
        {
            //resxManager = new ResourceManager("Ivs.Resources.Resource.Res", typeof(I18n).Assembly);
            //GetMessageResource();
        }

        ///// <summary>
        ///// Get resource file
        ///// </summary>
        ///// <param name="functionID"></param>
        ///// <returns></returns>
        //private void GetScreenDisplayResource()
        //{
        //    string langID = string.IsNullOrEmpty(UserSession.LangId) ? Ivs.Core.Common.CommonData.Language.English : UserSession.LangId;
        //    resxScreenDisplay = new ResourceManager(String.Format("Ivs.Ihrm.Core.Data.ScreenDisplay_{0}", langID), typeof(I18n).Assembly);
        //}
        ///// <summary>
        ///// Get resource file
        ///// </summary>
        ///// <param name="functionID"></param>
        ///// <returns></returns>
        //public void GetScreenDisplayResource(string _langID)
        //{
        //    //ResourceManager resxScreenDisplay;
        //    string langID = string.IsNullOrEmpty(_langID) ? Ivs.Ihrm.Core.Data.CommonData.Language.En : _langID;
        //    resxScreenDisplay = new ResourceManager(String.Format("Ivs.Ihrm.Core.Data.ScreenDisplay_{0}", langID), typeof(I18n).Assembly);
        //}
        ///// <summary>
        ///// Get resource file
        ///// </summary>
        ///// <param name="functionID"></param>
        ///// <returns></returns>
        //private void GetMessageResource()
        //{
        //    string langID = string.IsNullOrEmpty(UserSession.LangId) ? Ivs.Ihrm.Core.Data.CommonData.Language.En : UserSession.LangId;
        //    resxMessage = new ResourceManager(String.Format("Ivs.Ihrm.Core.Data.Message_{0}", langID), typeof(I18n).Assembly);
        //}

        //public static string GetString(string controlID)
        //{
        //    string key = functionID + "_" + controlID;
        //    return resxManager.GetString(key, currentInfo);
        //}

        public static string GetMessage(string key)
        {
            System.Globalization.CultureInfo currentInfo = Thread.CurrentThread.CurrentUICulture;
            return resxManager.GetString(key, currentInfo);
        }
        public static string GetMessage(string key, string languageID)
        {
            System.Globalization.CultureInfo currentInfo = new System.Globalization.CultureInfo(languageID);
            ResourceManager resxMessage = new ResourceManager("Ivs.Resources.Resource.Res", typeof(I18n).Assembly);
            return resxMessage.GetString(key, currentInfo);
            
        }
    }

}
