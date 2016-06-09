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
    public static partial class DropDownListExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WebDropDownList IvsDropDownList(this HtmlHelper helper, string name, IEnumerable<SelectListItem> dataSource, object value, object htmlAttributes)
        {
            return new WebDropDownList(helper, name, dataSource, value, htmlAttributes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        //public static WebDropDownList IvsDropDownList(this HtmlHelper helper, string name)
        //{
        //    return IvsDropDownList(helper, name, null, null, null);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static WebDropDownList IvsDropDownList(this HtmlHelper helper, string name, IEnumerable<SelectListItem> dataSource)
        {
            return IvsDropDownList(helper, name, dataSource, null, null);
        }

        public static WebDropDownList IvsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> dataSource, object htmlAttributes)
        {
            //Get name
            var name = ExpressionHelper.GetExpressionText(expression);

            //Get value from metadata
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            return IvsDropDownList(helper, name, dataSource, metadata.Model, htmlAttributes);
        }

        public static WebDropDownList IvsDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> dataSource)
        {
            //Get name
            var name = ExpressionHelper.GetExpressionText(expression);

            //Get value from metadata
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            return IvsDropDownList(helper, name, dataSource, metadata.Model, null);
        }
    }
}
