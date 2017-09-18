
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Windsor.Commons.Core;
using Windsor.Commons.DataAnnotations;
using Windsor.Commons.NodeDomain;
using Windsor.OpenNode2.RestEndpoint.DataAnnotations;

namespace Windsor.OpenNode2.RestEndpoint.Models
{
    [Serializable]
    public class QueryParameters : BaseAuthenticationParameters
    {
        [MustBeNullOrEmpty("The query parameter \"{0}\" must not be specified for this service.")]
        public string Node
        {
            get;
            set;
        }
        public string Dataflow
        {
            get;
            set;
        }
        [Required(ErrorMessage = "The query parameter \"{0}\" is required for this service.")]
        public string Request
        {
            get;
            set;
        }
        [ValidRestParams()]
        public string Params
        {
            get;
            set;
        }
        [Range(0, int.MaxValue, ErrorMessage = "The query parameter \"{0}\" must be between {1:N0} and {2:N0} for this service.")]
        public int? RowId
        {
            get;
            set;
        }
        [Range(-1, int.MaxValue, ErrorMessage = "The query parameter \"{0}\" must be between {1:N0} and {2:N0} for this service.")]
        public int? MaxRows
        {
            get;
            set;
        }
        public string XsltName
        {
            get;
            set;
        }
        public bool? ZipResults
        {
            get;
            set;
        }
        public virtual ByIndexOrNameDictionary<string> ParseParams()
        {
            ByIndexOrNameDictionary<string> parameterDictionary = null;
            if (!string.IsNullOrWhiteSpace(Params))
            {
                string propDisplayName = DataAnnotationsHelper.GetDisplayNameForProperty(this.GetType(), "Params");

                string errorMessage = ValidRestParamsAttribute.ParseParams(Params, propDisplayName, out parameterDictionary);

                if (errorMessage != null)
                {
                    throw new ArgumentException(errorMessage);
                }
            }
            if (!string.IsNullOrEmpty(XsltName))
            {
                if (parameterDictionary == null)
                {
                    parameterDictionary = new ByIndexOrNameDictionary<string>(true);
                }
                parameterDictionary.Add(CommonQueryParameterKeys.XSLT_RESULTS_TRANSFORMATION_NAME, XsltName);
            }
            return parameterDictionary;
        }
    }
}