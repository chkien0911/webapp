using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Controls.CustomControls.Infrastructure;
using System.Web.Mvc;
using Ivs.Core.Common;
using Ivs.Controls.CustomControls.Infrastructure.BaseControl;

namespace Ivs.Controls.CustomControls.Web.Extensions
{
    public static partial class ButtonExtension
    {
        public static WebButton IvsButton(this HtmlHelper helper, string name, string caption, CommonData.ButtonCategory category, CommonData.ButtonWebType type, object htmlAttribtes)
        {
            return (new WebButton(helper, name, caption, category, type, htmlAttribtes));
        }

        public static WebButton IvsButton(this HtmlHelper helper, string name, string caption, CommonData.ButtonCategory category, CommonData.ButtonWebType type)
        {
            return (new WebButton(helper, name, caption, category, type));
        }

        public static WebButton IvsButton(this HtmlHelper helper, string name, string caption, CommonData.ButtonCategory category)
        {
            return (new WebButton(helper, name, caption, category));
        }

        public static WebButton IvsButton(this HtmlHelper helper, string name, string caption)
        {
            return (new WebButton(helper, name, caption));
        }

        public static WebButton IvsButton(this HtmlHelper helper, string name, CommonData.ButtonCategory category)
        {
            return (new WebButton(helper, name, category));
        }

        public static WebButton IvsButton(this HtmlHelper helper, string name, CommonData.ButtonCategory category, CommonData.ButtonWebType type)
        {
            return (new WebButton(helper, name, category, type));
        }

        public static WebButton IvsButton(this HtmlHelper helper, string name)
        {
            return (new WebButton(helper, name));
        }

        public static WebButton IvsButton(this HtmlHelper helper)
        {
            return (new WebButton(helper));
        }
    }
}
