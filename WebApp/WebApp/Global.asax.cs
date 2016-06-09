using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ivs.Core.Interface;
using Ivs.Core.Web.Data;
using System.Web.Security;
using Ivs.Core.Web.ModelBinder;

namespace WebApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            #region Custom binder

            ModelBinders.Binders.Add(typeof(IModel), new BaseModelBinder());
            ModelBinders.Binders.Add(typeof(DateTime), new DateTimeModelBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new DateTimeModelBinder());
            ModelBinders.Binders.Add(typeof(int), new IntegerModelBinder());
            ModelBinders.Binders.Add(typeof(int?), new IntegerModelBinder());
            ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
            ModelBinders.Binders.Add(typeof(float), new FloatModelBinder());
            ModelBinders.Binders.Add(typeof(float?), new FloatModelBinder());
            ModelBinders.Binders.Add(typeof(double), new DoubleModelBinder());
            ModelBinders.Binders.Add(typeof(double?), new DoubleModelBinder());

            #endregion
        }

        protected void Application_EndRequest()
        {
            var context = new HttpContextWrapper(this.Context);

            // If we're an ajax request and forms authentication caused a 302,
            // then we actually need to do a 401
            if (FormsAuthentication.IsEnabled && context.Response.StatusCode == 302
                && context.Request.IsAjaxRequest())
            {
                context.Response.Clear();
                context.Response.StatusCode = 403;
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
        }

        protected void Session_Start(object src, EventArgs e)
        {
            if (Context.Session != null && Context.Session.IsNewSession)
            {
                string sCookieHeader = Request.Headers["Cookie"];
                if (sCookieHeader != null && sCookieHeader.IndexOf("ASP.NET_SessionId") >= 0)
                    Response.Redirect("~/Account/Login");
            }
        }
    }
}