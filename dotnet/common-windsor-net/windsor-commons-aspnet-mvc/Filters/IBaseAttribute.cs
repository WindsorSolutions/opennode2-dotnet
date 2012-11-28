using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Windsor.Commons.AspNet.Mvc.Filters
{
    public interface IBaseAttribute : IFilter
    {
        int Position
        {
            get;
            set;
        }
    }
}