using System.Web;
using System.Web.Mvc;
using Ivs.Core.Attributes;

namespace WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());

            filters.Add(new CustomHandleErrorAttribute());
        }
    }
}