using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using Windsor.Commons.Core;

namespace Windsor.Commons.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class AllOrNoneAttribute : DependentPropertiesAttribute
    {
        public AllOrNoneAttribute(params string[] otherPropertyNames)
            : base(otherPropertyNames)
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyValues = GetOtherPropertyValues(validationContext);

            var otherUnspecifiedPropertyDisplayNames = GetUnspecifiedPropertyDisplayNames(otherPropertyValues);
            var otherSpecifiedPropertyDisplayNames = GetSpecifiedPropertyDisplayNames(otherPropertyValues);

            bool isValueSpecified = IsValueSpecified(value);

            string quote = QuotePropertyNamesInErrorMessage ? "\"" : string.Empty;

            if (isValueSpecified && (otherUnspecifiedPropertyDisplayNames != null))
            {
                string valuesString = StringUtils.JoinCommaEnglish(otherUnspecifiedPropertyDisplayNames, QuotePropertyNamesInErrorMessage);
                var errorMessage = string.Format("A value for {0}{1}{2} was specified so {3} for {4} must also be specified.",
                                                 quote, validationContext.DisplayName, quote, otherUnspecifiedPropertyDisplayNames.Count > 1 ?
                                                 "values" : "a value", valuesString);
                return new ValidationResult(errorMessage);
            }
            else if (!isValueSpecified && (otherSpecifiedPropertyDisplayNames != null))
            {
                string valuesString = StringUtils.JoinCommaEnglish(otherSpecifiedPropertyDisplayNames, QuotePropertyNamesInErrorMessage);
                var errorMessage = string.Format("A value for {0}{1}{2} was not specified so {3} for {4} cannot be specified.",
                                                 quote, validationContext.DisplayName, quote, otherSpecifiedPropertyDisplayNames.Count > 1 ?
                                                 "values" : "a value", valuesString);
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }
    }
}