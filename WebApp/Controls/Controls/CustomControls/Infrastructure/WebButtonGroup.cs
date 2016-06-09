using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ivs.Core.Interface;
using System.Web;
using Ivs.Controls.CustomControls.Infrastructure.BaseControl;

namespace Ivs.Controls.CustomControls.Infrastructure
{
    public class WebButtonGroup : WebBaseControl, IWebControl, IHtmlString//IWebButtonGroup
    {
        public List<WebButton> WebButtons { get; private set; }

        public WebButtonGroup(HtmlHelper helper)
        {
            this.WebButtons = new List<WebButton>();
            base.Helper = helper;
        }

        public WebButtonGroup(HtmlHelper helper, List<WebButton> buttons)
        {
            this.WebButtons = buttons;
            base.Helper = helper;
        }

        public WebButtonGroup Buttons(Action<WebButtonGroup> buttons)
        {
            buttons(this);
            return this;
        }

        public WebButton Add(WebButton button)
        {
            this.WebButtons.Add(button);
            return button;
        }

        public string ToHtmlString()
        {
            var defaultDivToolbarClass = "btn-toolbar";

            //Div wraps the grid
            TagBuilder divToolbarBuilder = new TagBuilder("div");
            divToolbarBuilder.AddCssClass(defaultDivToolbarClass);
            
            //Add rendered table html to wrap
            divToolbarBuilder.InnerHtml = RenderControl();

            // Return the string
            return (divToolbarBuilder.ToString(TagRenderMode.Normal));
        }

        public string RenderControl()
        {
            //var defailtWrapDivClass = "btn-group btn-group-justified";
            var defaultDivBtnGrpClass = "btn-group btn-group-sm btn-group-md";

            //Div to recognize responsive table
            //TagBuilder divWrapBuilder = new TagBuilder("div");
            ////Add class for Div
            //divWrapBuilder.AddCssClass(defailtWrapDivClass);

            //Div to recognize responsive table
            TagBuilder divBtnGrpBuilder = new TagBuilder("div");
            //Add class for Div
            divBtnGrpBuilder.AddCssClass(defaultDivBtnGrpClass);

            //Add rendered table html to responsive
            divBtnGrpBuilder.InnerHtml = RendreButtons();

            //Add rendered table html to wrap
            return divBtnGrpBuilder.ToString();
        }

        private string RendreButtons()
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (WebButton button in this.WebButtons)
            {
                strBuilder.AppendLine(button.ToHtmlString());
            }

            return strBuilder.ToString();
        }
    }
}
