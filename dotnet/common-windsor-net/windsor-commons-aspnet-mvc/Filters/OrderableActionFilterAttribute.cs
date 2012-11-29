using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Windsor.Commons.AspNet.WebApi.Filters
{
    public class OrderableActionFilterAttribute : ActionFilterAttribute, IOrderableFilter
    {
        public int Order
        {
            get;
            set;
        }

        public OrderableActionFilterAttribute()
        {
            this.Order = 0;
        }
        public OrderableActionFilterAttribute(int order)
        {
            this.Order = order;
        }
    }
}