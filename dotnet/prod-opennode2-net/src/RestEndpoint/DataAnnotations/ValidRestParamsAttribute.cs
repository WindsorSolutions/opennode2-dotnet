using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Windsor.Commons.Core;
using Windsor.Commons.DataAnnotations;
using Windsor.Commons.NodeDomain;

namespace Windsor.OpenNode2.RestEndpoint.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidRestParamsAttribute : ValidationAttribute
    {
        public ValidRestParamsAttribute()
        {
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                ByIndexOrNameDictionary<string> parameterDictionary;
                string errorMessage = ParseParams(value.ToString(), validationContext.DisplayName, out parameterDictionary);

                if (errorMessage != null)
                {
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
        public static string ParseParams(string restParamsString, string propertyDisplayName, out ByIndexOrNameDictionary<string> parameterDictionary)
        {
            parameterDictionary = null;
            string errorMessage = null;
            if (!string.IsNullOrWhiteSpace(restParamsString))
            {
                ByIndexOrNameDictionary<string> parameters = new ByIndexOrNameDictionary<string>(true);
                List<string> keyValueParameters = StringUtils.SplitAndReallyRemoveEmptyEntries(restParamsString, ';');
                int count = 1;
                CollectionUtils.ForEachBreak(keyValueParameters, delegate(string keyValueParameter)
                {
                    int pipeIndex = keyValueParameter.IndexOf('|');
                    if (pipeIndex < 1)
                    {
                        errorMessage = string.Format("The query parameter \"{0}\" has invalid content for parameter {1}: \"{2}\"",
                                                     propertyDisplayName, count.ToString(), keyValueParameter);
                        return false;
                    }
                    string key = keyValueParameter.Substring(0, pipeIndex).Trim();
                    string value = string.Empty;
                    if (pipeIndex < (keyValueParameter.Length - 1))
                    {
                        value = keyValueParameter.Substring(pipeIndex + 1).Trim();
                    }
                    parameters.Add(key, value);
                    ++count;
                    return true;
                });
                if (parameters.Count > 0)
                {
                    parameterDictionary = parameters;
                }
            }
            return errorMessage;
        }
    }
}