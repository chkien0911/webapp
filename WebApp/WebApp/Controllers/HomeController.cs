using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.Models.Systems;
using System.Data;
using Ivs.Core.Web.Controllers;
using System.Threading;
using Ivs.Core.Data;

namespace WebApp.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InvalidRequest()
        {
            ViewBag.Message = "Request is not valid";
            return View();
        }

        public ActionResult Error()
        {
            return View("Error", "_MainLayout");
        }
        
        [AllowAnonymous]
        public ActionResult ChangeLanguage(string id)
        {
            string urlCurent = Request.UrlReferrer.ToString();
            if (!CommonMethod.IsNullOrEmpty(id))
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(id);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(id);
                Session["Language"] = id;

                switch (id)
                {
                    case CommonData.CultureInfo.English:
                        UserSession.LangId = CommonData.Language.English;
                        break;
                    case CommonData.CultureInfo.VietNamese:
                        UserSession.LangId = CommonData.Language.VietNamese;
                        break;
                    case CommonData.CultureInfo.Japanese:
                        UserSession.LangId = CommonData.Language.Japanese;
                        break;
                    default:
                        UserSession.LangId = CommonData.Language.English;
                        break;
                }
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(CommonData.CultureInfo.English);
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(CommonData.CultureInfo.English);
                Session["Language"] = CommonData.CultureInfo.English;
            }
            //Link to the Index Page
            return Json(new { success = true, redirectUrl = urlCurent }, JsonRequestBehavior.AllowGet);
        }
    }
}
