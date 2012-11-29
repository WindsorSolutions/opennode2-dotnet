using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Windsor.Commons.AspNet.WebApi.Filters
{
    public interface IOrderableFilter : IFilter
    {
        int Order
        {
            get;
            set;
        }
    }
}