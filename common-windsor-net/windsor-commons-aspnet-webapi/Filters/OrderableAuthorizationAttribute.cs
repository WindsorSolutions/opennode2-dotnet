using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Windsor.Commons.AspNet.WebApi.Filters
{
    public class OrderableAuthorizationAttribute : AuthorizationFilterAttribute, IOrderableFilter
    {
        public int Order
        {
            get;
            set;
        }

        public OrderableAuthorizationAttribute()
        {
            this.Order = 0;
        }
        public OrderableAuthorizationAttribute(int order)
        {
            this.Order = order;
        }
    }
}