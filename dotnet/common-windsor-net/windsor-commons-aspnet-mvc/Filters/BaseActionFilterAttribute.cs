using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Windsor.Commons.AspNet.Mvc.Filters
{
    public class BaseActionFilterAttribute : ActionFilterAttribute, IBaseAttribute
    {
        public int Position
        {
            get;
            set;
        }

        public BaseActionFilterAttribute()
        {
            this.Position = 0;
        }
        public BaseActionFilterAttribute(int positon)
        {
            this.Position = positon;
        }
    }
}