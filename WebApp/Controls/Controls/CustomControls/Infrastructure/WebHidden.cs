using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Interface;
using System.Web;
using System.Web.Mvc;
using Ivs.Core.Common;
using Ivs.Controls.CustomControls.Infrastructure.BaseControl;

namespace Ivs.Controls.CustomControls.Infrastructure
{
    public class WebHidden : WebBaseEdit, IWebControl, IHtmlString
    {
        #region Constructors

        public WebHidden(HtmlHelper helper, string name, object value, object htmlAttributes)
            : base(helper, name, value, htmlAttributes)
        {
        }

        #endregion

        public string ToHtmlString()
        {
            return this.RenderControl();
        }

        public string RenderControl()
        {
            TagBuilder builder = new TagBuilder("input");
            builder.Attributes.Add("name", base.Name);
            builder.Attributes.Add("id", base.Name);
            builder.Attributes.Add("type", "hidden");
            builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
            if (base.MaxLength > 0)
            {
                builder.Attributes.Add("maxlength", CommonMethod.ParseString(base.MaxLength));
            }
            
            //Add validation attributes
            foreach (var attr in base.ValidationAttributes)
            {
                builder.Attributes.Add(attr.Key, CommonMethod.ParseString(attr.Value));
            }

            //Merge htmlAttributes if any with replateExit mode 
            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(base.HtmlAttributes), true);

            if (base.IsPrimary)
            {
                builder.AddCssClass("primary-control");
            }
            if (base.IsUnique)
            {
                builder.AddCssClass("unique-control");
            }

            //Gen html textbox inside div tag
            return (builder.ToString(TagRenderMode.Normal));
        }
    }
}
