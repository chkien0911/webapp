using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Controls.CustomControls.Infrastructure;
using System.Web.Mvc;

namespace Ivs.Controls.CustomControls.Web.Extensions
{
    public static partial class WebMenuExtension
    {
        public static WebMenu<TModel> IvsWebMenu<TModel>(this HtmlHelper helper)
        {
            return new WebMenu<TModel>(helper);
        }
    }
}
