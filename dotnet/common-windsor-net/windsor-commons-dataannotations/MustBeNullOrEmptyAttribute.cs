using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Windsor.Commons.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MustBeNullOrEmptyAttribute : ValidationAttribute
    {
        public MustBeNullOrEmptyAttribute()
            : base("{0} must not be specified.")
        {
        }
        public MustBeNullOrEmptyAttribute(string errorMessage)
            : base(errorMessage)
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value.ToString().Length != 0)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}