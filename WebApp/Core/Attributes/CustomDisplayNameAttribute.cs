using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Ivs.Core.Common;
using Ivs.Resources.Common;
using System.Web.Mvc;

namespace Ivs.Core.Attributes
{
    public class CustomDisplayNameAttribute : DisplayNameAttribute
    {
        private string _resourceKey = CommonData.StringEmpty;
        private string _messageText = CommonData.StringEmpty;
        public CustomDisplayNameAttribute(string resourceKey)
        {
            this._resourceKey = resourceKey;
        }

        public override string DisplayName
        {
            get
            {
                _messageText = I18n.GetMessage(this._resourceKey);
                return CommonMethod.IsNullOrEmpty(_messageText) ? base.DisplayName : _messageText;
            }
        }
    }
}
