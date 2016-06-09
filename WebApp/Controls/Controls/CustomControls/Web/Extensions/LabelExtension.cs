using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ivs.Core.Data;
using Ivs.Core.Common;
using Ivs.Controls.CustomControls.Infrastructure;
using System.Linq.Expressions;
using System.Web.Routing;
using System.ComponentModel.DataAnnotations;

namespace Ivs.Controls.CustomControls.Web.Extensions
{
    public static partial class LabelExtensiton
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static MvcHtmlString IvsLabel(this HtmlHelper helper, string name, string labelText, object htmlAttributes)
        {
            //Add class to recognize boostrap
            var defaultControlClass = "col-sm-2 col-md-2 control-label";

            TagBuilder builder = new TagBuilder("label");
            builder.Attributes.Add("for", name);

            if (CommonMethod.IsNullOrEmpty(labelText))
            {
                var metadata = ModelMetadata.FromStringExpression(name, helper.ViewData);
                labelText = metadata.DisplayName;
            }
            builder.SetInnerText(CommonMethod.IsNullOrEmpty(labelText) ? name : labelText);
            //Merge htmlAttributes if any with replateExit mode 
            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), true);
            //Add class
            string attributeClass = htmlAttributes.GetCssClass();
            bool replace = attributeClass.Contains("replace");
            builder.AddCssClass(CommonMethod.IsNullOrEmpty(attributeClass)
                                    ? defaultControlClass
                                    : replace ? attributeClass : defaultControlClass + " " + attributeClass);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MvcHtmlString IvsLabel(this HtmlHelper helper, string name)
        {
            return IvsLabel(helper, name, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MvcHtmlString IvsLabel(this HtmlHelper helper, string name, string labelText)
        {
            return IvsLabel(helper, name, labelText, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="helper"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static MvcHtmlString IvsLabelFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string labelText, object htmlAttributes)
        {
            //Get name
            var name = ExpressionHelper.GetExpressionText(expression);

            //Get value from metadata
            //var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            return IvsLabel(helper, name, labelText, htmlAttributes);
        }

        public static MvcHtmlString IvsLabelFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            return IvsLabelFor<TModel, TProperty>(helper, expression, null, null);
        }

        public static MvcHtmlString IvsLabelFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string labelText)
        {
            return IvsLabelFor<TModel, TProperty>(helper, expression, labelText, null);
        }
    }
}
