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
    public class WebDropDownList : WebBaseDropDown, IWebControl, IHtmlString
    {
        #region Constructors

        public WebDropDownList(HtmlHelper helper, string name, IEnumerable<SelectListItem> dataSource, object value, object htmlAttributes)
            : base(helper, name, dataSource, value, htmlAttributes)
        {
        }
        
        #endregion

        public string ToHtmlString()
        {
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
            //Creating a select element using TagBuilder class which will create a dropdown.
            TagBuilder builder = new TagBuilder("select");
            //Setting the name and id attribute with name parameter passed to this method.
            builder.Attributes.Add("name", base.Name);
            builder.Attributes.Add("id", base.Name);
            if (base.MaxLength > 0)
            {
                builder.Attributes.Add("maxlength", CommonMethod.ParseString(base.MaxLength));
            }

            //Assigning the attributes passed as a htmlAttributes object.
            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(base.HtmlAttributes), true);

            switch (base.Mode)
            {
                case CommonData.Mode.View:
                    //builder.AddCssClass("select2-container-disabled");
                    //builder.Attributes.Add("readonly", "readonly");
                    builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
                    break;
                case CommonData.Mode.Edit:
                    if (base.IsUnique)
                    {
                        //builder.AddCssClass("select2-container-disabled");
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
                    //builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
                    break;
                case CommonData.Mode.Copy:
                    //builder.Attributes.Remove("readonly");
                    //if (base.IsUnique)
                    //{
                    //    builder.Attributes.Add("value", CommonData.StringEmpty);
                    //}
                    //else
                    //{
                    //    builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
                    //}
                    if (base.IsFocus)
                    {
                        builder.Attributes.Add("autofocus", CommonMethod.ParseString(base.IsFocus));
                    }
                    break;
                case CommonData.Mode.New:
                    //builder.Attributes.Remove("readonly");
                    //builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
                    if (base.IsFocus)
                    {
                        builder.Attributes.Add("autofocus", CommonMethod.ParseString(base.IsFocus));
                    }
                    break;
                case CommonData.Mode.Search:
                    //builder.Attributes.Remove("readonly");
                    //builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
                    if (base.IsFocus)
                    {
                        builder.Attributes.Add("autofocus", CommonMethod.ParseString(base.IsFocus));
                    }
                    break;
                default:
                    //builder.Attributes.Remove("readonly");
                    //builder.Attributes.Add("value", CommonMethod.ParseString(base.Value));
                    if (base.IsFocus)
                    {
                        builder.Attributes.Add("autofocus", CommonMethod.ParseString(base.IsFocus));
                    }
                    break;
            }

            if (base.Readonly)
            {
                //builder.AddCssClass("select2-container-disabled");
                builder.Attributes.Add("readonly", "readonly");
            }

            foreach (var attr in base.ValidationAttributes)
            {
                builder.Attributes.Add(attr.Key, CommonMethod.ParseString(attr.Value));
            }

            //builder.AddCssClass(defaultControlClass);
            builder.AddCssClass("combobox");
            if (base.IsPrimary)
            {
                builder.AddCssClass("primary-control");
            }
            if (base.IsUnique)
            {
                builder.AddCssClass("unique-control");
            }

            //Created StringBuilder object to store option data fetched oen by one from list.
            StringBuilder options = new StringBuilder();
            //Iterated over the IEnumerable list.
            if (this.DataSource != null)
            {
                foreach (var item in this.DataSource)
                {
                    string selectedStr = ((!CommonMethod.IsNullOrEmpty(this.Value) && item.Value.Equals(this.Value)) || item.Selected
                                            ? "selected = 'selected'"
                                            : CommonData.StringEmpty);
                    //Each option represents a value in dropdown. For each element in the list, option element is created and appended to the stringBuilder object.
                    if (CommonMethod.IsNullOrEmpty(item.Value))
                    {
                        options = options.AppendLine("<option value=''>.</option>");
                    }
                    else
                    {
                        options = options.AppendLine("<option value='" + item.Value + "' " + selectedStr + ">" + item.Text + "</option>");
                    }
                }
            }
            //assigned all the options to the dropdown using innerHTML property.
            builder.InnerHtml = options.ToString();


            //Gen html textbox inside div tag
            return (builder.ToString(TagRenderMode.Normal));
        }
    }
}
