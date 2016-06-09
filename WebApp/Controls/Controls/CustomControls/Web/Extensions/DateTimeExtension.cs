using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ivs.Controls.CustomControls.Infrastructure;
using System.Linq.Expressions;
using Ivs.Controls.CustomControls.Infrastructure.BaseControl;

namespace Ivs.Controls.CustomControls.Web.Extensions
{
    public static partial class DateTimeExtension
    {
        public static WebTexBox IvsDateTime(this HtmlHelper helper, string name, object value)
        {
            return IvsDateTime(helper, name, value, null);
        }

        public static WebTexBox IvsDateTime(this HtmlHelper helper, string name)
        {
            return IvsDateTime(helper, name, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WebTexBox IvsDateTime(this HtmlHelper helper, string name, object value, object htmlAttributes)
        {
            return new WebTexBox(helper, name, value, htmlAttributes, Core.Common.CommonData.InputWebType.date);
        }

        public static WebTexBox IvsDateTimeFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            return IvsDateTimeFor<TModel, TProperty>(helper, expression, null);
        }

        public static WebTexBox IvsDateTimeFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            //Get name
            var name = ExpressionHelper.GetExpressionText(expression);

            //Get value from metadata
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            return IvsDateTime(helper, name, metadata.Model, htmlAttributes);
        }
    }
}
