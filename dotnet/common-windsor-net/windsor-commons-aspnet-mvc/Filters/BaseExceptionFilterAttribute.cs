using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Windsor.Commons.AspNet.Mvc.Filters
{
    public class BaseExceptionFilterAttribute : ExceptionFilterAttribute, IBaseAttribute
    {
        public int Position
        {
            get;
            set;
        }

        public BaseExceptionFilterAttribute()
        {
            this.Position = 0;
        }
        public BaseExceptionFilterAttribute(int positon)
        {
            this.Position = positon;
        }
    }
}