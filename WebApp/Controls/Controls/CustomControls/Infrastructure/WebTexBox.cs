using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Ivs.Controls.CustomControls.Infrastructure.BaseControl;
using System.Threading;
using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.Infrastructure
{
    public class WebTexBox : WebBaseEdit, IWebControl, IHtmlString//IWebTexBox
    {
        #region Constructors

        public WebTexBox(HtmlHelper helper, string name, object value, object htmlAttributes, CommonData.InputWebType inputType)
            : base(helper, name, value, htmlAttributes, inputType)
        {
        }

        public WebTexBox(HtmlHelper helper, string name, object value, object htmlAttributes)
            : base(helper, name, value, htmlAttributes)
        {
        }

        #endregion

        #region Methods

        #region this methods


        #endregion

        public string ToHtmlString()
        {
            //No wrapping div
            if (base.IsNoWrap)
            {
                return RenderControl();
            }

            //Add class to recognize boostrap
            var defaultDivClass = this.WidthClass;

            //Div wraps the textbox
            TagBuilder divBuilder = new TagBuilder("div");
            //Add class for Div
            string attributeClass = base.HtmlAttributes.GetCssClass();
            
            //bool replace = attributeClass.Contains("replace");
            divBuilder.AddCssClass(CommonMethod.IsNullOrEmpty(attributeClass)
                                    ? defaultDivClass
                                    : attributeClass);

            //Gen html textbox inside div tag
            divBuilder.InnerHtml = RenderControl();

            //Using for 1 tag
            return (divBuilder.ToString(TagRenderMode.Normal));
        }

        public string RenderControl()
        {
            //var viewDataValues = this.Helper.ViewData.Values;

            var defaultControlClass = "form-control";
            TagBuilder builder = new TagBuilder("input");
            //Merge htmlAttributes if any with replateExit mode 
            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(base.HtmlAttributes), true);

            builder.Attributes.Add("name", base.Name);
            builder.Attributes.Add("id", base.Name);
            //builder.Attributes.Add("type", base.InputType.ToString());
            switch (base.InputType)
            {
                case CommonData.InputWebType.text:
                    builder.Attributes.Add("type", "text");
                    break;
                case CommonData.InputWebType.password:
                    builder.Attributes.Add("type", "password");
                    break;
                case CommonData.InputWebType.date:
                    builder.Attributes.Add("type", "text");
                    defaultControlClass += " datepicker text-center";
                    if (UserSession.LangId == CommonData.Language.Japanese)
                    {
                        builder.Attributes.Add("data-date-format", CommonData.DateFormat.Yyyy_MM_dd.ToUpper());
                    }
                    else if (UserSession.LangId == CommonData.Language.VietNamese)
                    {
                        builder.Attributes.Add("data-date-format", CommonData.DateFormat.DdMMyyyy.ToUpper());
                    }
                    else
                    {
                        builder.Attributes.Add("data-date-format", CommonData.DateFormat.MMddyyyy.ToUpper());
                    }
                    
                    break;
                case CommonData.InputWebType.datetime:
                    builder.Attributes.Add("type", "text");
                    defaultControlClass += " datetimepicker text-center";
                    if (UserSession.LangId == CommonData.Language.Japanese)
                    {
                        builder.Attributes.Add("data-date-format", CommonData.DateFormat.Yyyy_MM_ddHHmmss.ToUpper());
                    }
                    else if (UserSession.LangId == CommonData.Language.VietNamese)
                    {
                        builder.Attributes.Add("data-date-format", CommonData.DateFormat.DdMMyyyyHHmmss.ToUpper());
                    }
                    else
                    {
                        builder.Attributes.Add("data-date-format", CommonData.DateFormat.MMddyyyyHHmmss.ToUpper());
                    }
                    break;
                case CommonData.InputWebType.time:
                    builder.Attributes.Add("type", "text");
                    defaultControlClass += " timepicker text-center";
                    break;
                case CommonData.InputWebType.email:
                    builder.Attributes.Add("type", "text");
                    defaultControlClass += " email";
                    break;
                case CommonData.InputWebType.number:
                    builder.Attributes.Add("type", "text");
                    defaultControlClass += " number  text-right";
                    break;
                case CommonData.InputWebType.month:
                    builder.Attributes.Add("type", "text");
                    defaultControlClass += " month";
                    break;
                case CommonData.InputWebType.week:
                    builder.Attributes.Add("type", "text");
                    defaultControlClass += " week";
                    break;
                default:
                    builder.Attributes.Add("type", "text");
                    break;
            }

            if (base.MaxLength > 0)
            {
                builder.Attributes.Add("maxlength", CommonMethod.ParseString(base.MaxLength));
            }
            switch (base.Mode)
            {
                case CommonData.Mode.View:
                    //builder.Attributes.Add("readonly", "readonly");
                    builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
                    break;
                case CommonData.Mode.Edit:
                    if (base.IsUnique)
                    {
                        //builder.Attributes.Add("readonly", "readonly");
                    }
                    else
                    {
                        //builder.Attributes.Remove("readonly");
                        if (base.IsFocus)
                        {
                            builder.Attributes.Add("autofocus", CommonMethod.ParseString(base.IsFocus));
                        }
                    }
                    builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
                    break;
                case CommonData.Mode.Copy:
                    //builder.Attributes.Remove("readonly");
                    if (base.IsUnique)
                    {
                        builder.Attributes.Add("value", CommonData.StringEmpty);
                    }
                    else
                    {
                        builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
                    }
                    if (base.IsFocus)
                    {
                        builder.Attributes.Add("autofocus", CommonMethod.ParseString(base.IsFocus));
                    }
                    break;
                case CommonData.Mode.New:
                    //builder.Attributes.Remove("readonly");
                    builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
                    if (base.IsFocus)
                    {
                        builder.Attributes.Add("autofocus", CommonMethod.ParseString(base.IsFocus));
                    }
                    break;
                case CommonData.Mode.Search:
                    //builder.Attributes.Remove("readonly");
                    builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
                    if (base.IsFocus)
                    {
                        builder.Attributes.Add("autofocus", CommonMethod.ParseString(base.IsFocus));
                    }
                    break;
                default:
                    //builder.Attributes.Remove("readonly");
                    builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
                    if (base.IsFocus)
                    {
                        builder.Attributes.Add("autofocus", CommonMethod.ParseString(base.IsFocus));
                    }
                    break;
            }
            if (base.Readonly)
            {
                builder.Attributes.Add("readonly", "readonly");
            }

            //ModelMetadata modelMetadata = ModelMetadata.FromStringExpression(base.Name, base.Helper.ViewData);
            //IDictionary<string, object> valAttributes = base.Helper.GetUnobtrusiveValidationAttributes(base.Name, modelMetadata);

            //Add validation attributes
            foreach (var attr in base.ValidationAttributes)
            {
                builder.Attributes.Add(attr.Key, CommonMethod.ParseString(attr.Value));
            }

            //if (!CommonMethod.IsNullOrEmpty(modelMetadata.PropertyName))
            //{
            //    var requireAttr = modelMetadata.ContainerType.GetProperty(modelMetadata.PropertyName)
            //                       .GetCustomAttributes(typeof(RequiredAttribute), false);

            //    var lengthAttr = modelMetadata.ContainerType.GetProperty(modelMetadata.PropertyName)
            //                       .GetCustomAttributes(typeof(StringLengthAttribute), false);
            //}

            
            //Add class for control
            builder.AddCssClass(defaultControlClass);
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

        #endregion
    }
}
