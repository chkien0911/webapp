using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Ivs.Core.Common;
using Ivs.Controls.CustomControls.Infrastructure;
using Ivs.Controls.CustomControls.Infrastructure.BaseControl;

namespace Ivs.Controls.CustomControls.Web.Extensions
{
    public static partial class ButtonGroupExtension
    {

        public static WebButtonGroup IvsButtonGroup(this HtmlHelper helper, List<WebButton> buttons)
        {
            return new WebButtonGroup(helper, buttons);
        }

        public static WebButtonGroup IvsButtonGroup(this HtmlHelper helper)
        {
            return new WebButtonGroup(helper);
        }

        public static WebButtonGroup IvsButtonGroup(this HtmlHelper helper, CommonData.Mode mode)
        {
            List<WebButton> buttons = new List<WebButton>();
            if (mode == CommonData.Mode.Search)
            {
                buttons.Add(new WebButton(helper, "Search", CommonData.ButtonCategory.Search, CommonData.ButtonWebType.submit));
                buttons.Add(new WebButton(helper, "Copy", CommonData.ButtonCategory.Copy));
                buttons.Add(new WebButton(helper, "Add", CommonData.ButtonCategory.Add));
                buttons.Add(new WebButton(helper, "Edit", CommonData.ButtonCategory.Edit));
                buttons.Add(new WebButton(helper, "Detail", CommonData.ButtonCategory.Detail));
                buttons.Add(new WebButton(helper, "Delete", CommonData.ButtonCategory.Delete));
                buttons.Add(new WebButton(helper, "Refresh", CommonData.ButtonCategory.Refresh, CommonData.ButtonWebType.submit));
                buttons.Add(new WebButton(helper, "Print", CommonData.ButtonCategory.Print));
                buttons.Add(new WebButton(helper, "Export", CommonData.ButtonCategory.Export));
            }
            else if (mode == CommonData.Mode.View)
            {
                buttons.Add(new WebButton(helper, "Edit", CommonData.ButtonCategory.Edit));
                buttons.Add(new WebButton(helper, "Refresh", CommonData.ButtonCategory.Refresh, CommonData.ButtonWebType.reset));
                buttons.Add(new WebButton(helper, "Back", CommonData.ButtonCategory.Back));
            }
            else
            {
                buttons.Add(new WebButton(helper, "Save", CommonData.ButtonCategory.Save));
                //buttons.Add(new WebButton(helper, "SaveAndNext", CommonData.ButtonCategory.SaveAndNext));
                buttons.Add(new WebButton(helper, "Refresh", CommonData.ButtonCategory.Refresh, CommonData.ButtonWebType.reset));
                buttons.Add(new WebButton(helper, "Back", CommonData.ButtonCategory.Back));
            }

            return new WebButtonGroup(helper, buttons);
        }
    }
}
