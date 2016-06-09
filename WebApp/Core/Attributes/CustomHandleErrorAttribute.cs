using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ivs.Core.Log;
using System.Net;
using System.Web;
using System.Web.Routing;

namespace Ivs.Core.Attributes
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        private static readonly Logger log = new Logger();

        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            //var statusCode = (int)HttpStatusCode.InternalServerError;
            //if (filterContext.Exception is HttpException)
            //{
            //    statusCode = (filterContext.Exception as HttpException).GetHttpCode();
            //}
            //else if (filterContext.Exception is UnauthorizedAccessException)
            //{
            //    //to prevent login prompt in IIS
            //    // which will appear when returning 401.
            //    statusCode = (int)HttpStatusCode.Forbidden;
            //}
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            //write log
            log.Write(Logger.Level.Error, filterContext.Exception.Message);

            //return
            //var controllerName = (string)filterContext.RouteData.Values["controller"];
            //var actionName = (string)filterContext.RouteData.Values["action"];
            //var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            //var viewName = "~/Views/Shared/Error.cshtml";
            //filterContext.Result = new ViewResult
            //{
                
            //    ViewName = viewName,
            //    //MasterName = Master,
            //    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
            //    TempData = filterContext.Controller.TempData
            //};
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var urlHelper = new UrlHelper(filterContext.RequestContext);
                filterContext.HttpContext.Response.StatusCode = 403;
                filterContext.Result = new JsonResult
                {
                    Data = new
                    {
                        Error = "Session timeout",
                        RedirectURL = urlHelper.Action("Error", "Home"),
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Home" }, { "action", "Error" } });
            }
        }
    }
}
