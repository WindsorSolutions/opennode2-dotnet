using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace Windsor.Commons.AspNet.Mvc.Filters
{
    public class CustomFilterInfo : IComparable
    {
        public CustomFilterInfo(IFilter instance, FilterScope scope)
        {
            this.Instance = instance;
            this.Scope = scope;
        }

        public IFilter Instance
        {
            get;
            set;
        }
        public FilterScope Scope
        {
            get;
            set;
        }

        public int CompareTo(object obj)
        {
            if (obj is CustomFilterInfo)
            {
                var item = obj as CustomFilterInfo;

                if (item.Instance is IBaseAttribute)
                {
                    var attr = item.Instance as IBaseAttribute;
                    return (this.Instance as IBaseAttribute).Position.CompareTo(attr.Position);
                }
                else
                {
                    throw new ArgumentException("Object is of wrong type");
                }
            }
            else
            {
                throw new ArgumentException("Object is of wrong type");
            }
        }

        public FilterInfo ConvertToFilterInfo()
        {
            return new FilterInfo(this.Instance, this.Scope);
        }
    }
}