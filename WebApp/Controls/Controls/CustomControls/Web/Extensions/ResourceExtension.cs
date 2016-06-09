using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ivs.Resources.Common;

namespace Ivs.Controls.CustomControls.Web.Extensions
{
    public static partial class ResourceExtension
    {
        public static MvcHtmlString IvsResource(this HtmlHelper helper, string messageId)
        {
            string messageText = I18n.GetMessage(messageId);
            return new MvcHtmlString(helper.Raw(messageText).ToString());
        }

        public static MvcHtmlString IvsResource(this HtmlHelper helper, string messageId, string language)
        {
            string messageText = I18n.GetMessage(messageId, language);
            return new MvcHtmlString(helper.Raw(messageText).ToString());
        }
    }
}
