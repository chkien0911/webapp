using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Controls.CustomControls.Infrastructure;
using System.Web.Mvc;
using Ivs.Core.Common;
using System.Linq.Expressions;
using Ivs.Controls.CustomControls.Infrastructure.BaseControl;

namespace Ivs.Controls.CustomControls.Web.Extensions
{
    public static partial class HiddenExtension
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WebHidden IvsHidden(this HtmlHelper helper, string name, object value, object htmlAttributes)
        {
            return new WebHidden(helper, name, value, htmlAttributes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static WebHidden IvsHidden(this HtmlHelper helper, string name)
        {
            return IvsHidden(helper, name, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static WebHidden IvsHidden(this HtmlHelper helper, string name, object value)
        {
            return IvsHidden(helper, name, value, null);
        }

        public static WebHidden IvsHiddenFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            return IvsHiddenFor<TModel, TProperty>(helper, expression, null);
        }

        public static WebHidden IvsHiddenFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            //Get name
            var name = ExpressionHelper.GetExpressionText(expression);

            //Get value from metadata
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            return IvsHidden(helper, name, metadata.Model, htmlAttributes);
        }

    }
}
