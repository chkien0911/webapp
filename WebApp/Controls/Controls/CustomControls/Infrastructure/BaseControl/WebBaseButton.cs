using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.Infrastructure.BaseControl
{
    public class WebBaseButton : WebBaseControl
    {
        public virtual CommonData.IsAuthority IsAuthority 
        {
            get
            {
                CommonData.IsAuthority isAuthority = CommonData.IsAuthority.Allow;
                this.SetAuthorization();
                if (this.AuthorityDictionary != null)
                {
                    this.AuthorityDictionary.TryGetValue(this.ButtonCategory, out isAuthority);
                }
                return isAuthority;
            }
        }
        public virtual Dictionary<CommonData.ButtonCategory, CommonData.IsAuthority> AuthorityDictionary { get; protected set; }
        public virtual string Caption { get; protected set; }
        public virtual string IconName { get; protected set; }
        public virtual CommonData.ButtonCategory ButtonCategory { get; protected set; }
        public virtual CommonData.ButtonWebType ButtonType { get; protected set; }
        public bool IsDismissModal { get; protected set; }

        private void SetAuthorization()
        {
            if (this.Helper != null)
            {
                if (this.Helper.ViewBag.AuthorityDictionary != null)
                {
                    this.AuthorityDictionary = (Dictionary<CommonData.ButtonCategory, CommonData.IsAuthority>)this.Helper.ViewBag.AuthorityDictionary;
                }
            }
        }

        public WebBaseButton SetDismissModal(bool isDismissModal = true)
        {
            this.IsDismissModal = isDismissModal;
            return this;
        }

        public WebBaseButton SetCaption(string caption)
        {
            this.Caption = caption;
            return this;
        }

        public WebBaseButton SetIcon(string iconName)
        {
            this.IconName = iconName;
            return this;
        }

        public WebBaseButton SetCategory(CommonData.ButtonCategory category)
        {
            this.ButtonCategory = category;
            return this;
        }

        public WebBaseButton SetType(CommonData.ButtonWebType type)
        {
            this.ButtonType = type;
            return this;
        }


        
    }
}
