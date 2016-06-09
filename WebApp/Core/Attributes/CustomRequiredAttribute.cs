using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Ivs.Core.Common;
using Ivs.Resources.Common;
using System.Web.Mvc;

namespace Ivs.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class CustomRequiredAttribute : RequiredAttribute, IClientValidatable
    {
        private string _resourceKey = "COM_MSG_REQUIRED";

        public CustomRequiredAttribute()
            : this(CommonData.StringEmpty)
        {
        }

        public CustomRequiredAttribute(string resourceKey)
            : base()
        {
            if (!CommonMethod.IsNullOrEmpty(resourceKey))
            {
                this._resourceKey = resourceKey;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            string messageText = I18n.GetMessage(_resourceKey);
            return string.Format(messageText, name);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Type objType = validationContext.ObjectType;
            if (objType == typeof(DateTime) || objType == typeof(DateTime?))
            {
                if (CommonMethod.IsNullOrEmpty(value) || CommonMethod.ParseDateTime(value) == DateTime.MinValue)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            else
            {
                if (CommonMethod.IsNullOrEmpty(value))
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
                            ModelMetadata metadata,
                            ControllerContext context)
        {
            var clientValidationRule = new ModelClientValidationRule()
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "required"
            };

            return new[] { clientValidationRule };
        }
    }
}
