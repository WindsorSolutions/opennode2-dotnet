using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Windsor.Commons.AspNet.WebApi.Filters
{
    public class OrderableExceptionFilterAttribute : ExceptionFilterAttribute, IOrderableFilter
    {
        public int Order
        {
            get;
            set;
        }

        public OrderableExceptionFilterAttribute()
        {
            this.Order = 0;
        }
        public OrderableExceptionFilterAttribute(int order)
        {
            this.Order = order;
        }
    }
}