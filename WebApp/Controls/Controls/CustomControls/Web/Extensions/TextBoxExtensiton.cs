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
using System.Web;
using System.ComponentModel.DataAnnotations;
using Ivs.Controls.CustomControls.Infrastructure.BaseControl;

namespace Ivs.Controls.CustomControls.Web.Extensions
{
    public static partial class TextBoxExtensiton
    {
        public static WebTexBox IvsTextBox(this HtmlHelper helper, string name, object value)
        {
            return IvsTextBox(helper, name, value, null);
        }

        public static WebTexBox IvsTextBox(this HtmlHelper helper, string name)
        {
            return IvsTextBox(helper, name, null, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static WebTexBox IvsTextBox(this HtmlHelper helper, string name, object value, object htmlAttributes)
        {
            return new WebTexBox(helper, name, value, htmlAttributes);
            //Add class to recognize boostrap
            //var defaultDivClass = "col-sm-3 col-md-3";
            //var defaultControlClass = "form-control";

            ////Div wraps the textbox
            //TagBuilder divBuilder = new TagBuilder("div");
            ////Add class for Div
            //string attributeClass = htmlAttributes.GetCssClass();
            //bool replace = attributeClass.Contains("replace");
            //divBuilder.AddCssClass(CommonMethod.IsNullOrEmpty(attributeClass) 
            //                        ? defaultDivClass
            //                        : replace ? attributeClass : defaultDivClass + " " + attributeClass);

            ////Textbox content
            //TagBuilder builder = new TagBuilder("input");
            //builder.Attributes.Add("type", "text");
            //builder.Attributes.Add("name", name);
            //builder.Attributes.Add("id", name);
            //if (!CommonMethod.IsNullOrEmpty(value))
            //{
            //    builder.Attributes.Add("value", value.ToString());
            //}
            ////Merge htmlAttributes if any with replateExit mode 
            //builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), true);
            ////Add class for control
            //builder.AddCssClass(defaultControlClass);

            ////Gen html textbox inside div tag
            //divBuilder.InnerHtml = (builder.ToString(TagRenderMode.Normal));

            ////Using for 1 tag
            //return MvcHtmlString.Create(divBuilder.ToString(TagRenderMode.Normal));
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="helper"></param>
        ///// <param name="controlSetting"></param>
        ///// <returns></returns>
        //public static MvcHtmlString IvsTextBox(this HtmlHelper helper, ControlSetting controlSetting)
        //{
            
        //    return MvcHtmlString.Empty;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="TModel"></typeparam>
        ///// <typeparam name="TProperty"></typeparam>
        ///// <param name="helper"></param>
        ///// <param name="expression"></param>
        ///// <param name="controlSetting"></param>
        ///// <returns></returns>
        //public static MvcHtmlString IvsTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, ControlSetting controlSetting)
        //{
        //    //Get name
        //    var name = ExpressionHelper.GetExpressionText(expression);

        //    //Get value from metadata
        //    var metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

        //    //Change setting's properties by model
        //    controlSetting.Name = name;
        //    controlSetting.Value = metadata.Model;
        //    //controlSetting.SelectedValue = (string)metadata.Model;

        //    return IvsTextBox(helper, controlSetting);
        //}

        public static WebTexBox IvsTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            return IvsTextBoxFor<TModel, TProperty>(helper, expression, null);
        }

        public static WebTexBox IvsTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            //Get name
            var name = ExpressionHelper.GetExpressionText(expression);

            //Get value from metadata
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            return IvsTextBox(helper, name, metadata.Model, htmlAttributes);
        }

    }
}
