using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Reflection;
using Windsor.Commons.Core;

namespace Windsor.Commons.AspNet.WebApi.Filters
{
    public class OrderableFilterProvider : IFilterProvider
    {
        /// <summary>
        /// This method should be called AFTER all filters have been added to HttpConfiguration.Filters on app start
        /// </summary>
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Services.Add(typeof(System.Web.Http.Filters.IFilterProvider), new OrderableFilterProvider());
            var providers = configuration.Services.GetFilterProviders();
            var defaultprovider = providers.First(i => i is ActionDescriptorFilterProvider);

            configuration.Services.Remove(typeof(System.Web.Http.Filters.IFilterProvider), defaultprovider);
        }
        // Call Register() method above instead of new-ing this object
        protected OrderableFilterProvider()
        {
        }
        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("Configuration is null");
            }

            if (actionDescriptor == null)
            {
                throw new ArgumentNullException("ActionDescriptor is null");
            }

            IEnumerable<CustomFilterInfo> customActionFilters =
                actionDescriptor.GetFilters().Select(i => new CustomFilterInfo(i, FilterScope.Controller));
            IEnumerable<CustomFilterInfo> customControllerFilters =
                actionDescriptor.ControllerDescriptor.GetFilters().Select(i => new CustomFilterInfo(i, FilterScope.Controller));

            IEnumerable<FilterInfo> filters =
                customControllerFilters.Concat(customActionFilters).OrderBy(i => i).Select(i => i.ConvertToFilterInfo());
            return filters;
        }
        private class CustomFilterInfo : IComparable
        {
            public CustomFilterInfo(IFilter instance, FilterScope scope)
            {
                ExceptionUtils.ThrowIfNull(instance);
                Instance = instance;
                Scope = scope;
                InstanceBaseAttribute = Instance as IOrderableFilter;

                // See "Filtering in ASP.NET MVC": http://msdn.microsoft.com/en-us/library/gg416513(v=vs.98).aspx

                if (Instance is AuthorizationFilterAttribute)
                {
                    FilterByTypeOrder = 0;
                }
                else if (Instance is ActionFilterAttribute)
                {
                    FilterByTypeOrder = 1;
                }
                else if (Instance is ExceptionFilterAttribute)
                {
                    FilterByTypeOrder = 2;
                }
                else
                {
                    throw new ArgException("Unrecognized filter attribute type: {0}", Instance.GetType().Name);
                }
            }

            private IFilter Instance
            {
                get;
                set;
            }
            private FilterScope Scope
            {
                get;
                set;
            }
            private IOrderableFilter InstanceBaseAttribute
            {
                get;
                set;
            }
            private int FilterByTypeOrder
            {
                get;
                set;
            }

            public virtual int CompareTo(object obj)
            {
                var customFilterInfo = obj as CustomFilterInfo;

                ExceptionUtils.ThrowIfNull(customFilterInfo);

                int subOrderFilterCompare = FilterByTypeOrder - customFilterInfo.FilterByTypeOrder;

                if (subOrderFilterCompare != 0)
                {
                    return subOrderFilterCompare;
                }

                IOrderableFilter otherInstanceBaseAttribute = customFilterInfo.InstanceBaseAttribute;

                if (InstanceBaseAttribute != null)
                {
                    if (otherInstanceBaseAttribute != null)
                    {
                        return InstanceBaseAttribute.Order - customFilterInfo.InstanceBaseAttribute.Order;
                    }
                    else
                    {
                        // this is an IOrderableFilter, other is not, put this one first in the list always
                        return -1;
                    }
                }
                else if (otherInstanceBaseAttribute != null)
                {
                    // this is not an IOrderableFilter, other is an IOrderableFilter, put other before this one always in the list
                    return 1;
                }
                return 0; // Neither this nor other is an IOrderableFilter, assume user doesn't care, they are both put at the end of list
            }

            public FilterInfo ConvertToFilterInfo()
            {
                return new FilterInfo(this.Instance, this.Scope);
            }
        }
    }
}