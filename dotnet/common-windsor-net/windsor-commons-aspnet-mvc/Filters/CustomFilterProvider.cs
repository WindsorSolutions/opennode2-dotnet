using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Reflection;

namespace Windsor.Commons.AspNet.Mvc.Filters
{
    public class CustomFilterProvider : IFilterProvider
    {
        // Call Register() method below
        protected CustomFilterProvider()
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

            IEnumerable<CustomFilterInfo> customActionFilters = actionDescriptor.GetFilters().Select(i => new CustomFilterInfo(i, FilterScope.Controller));
            IEnumerable<CustomFilterInfo> customControllerFilters = actionDescriptor.ControllerDescriptor.GetFilters().Select(i => new CustomFilterInfo(i, FilterScope.Controller));

            return customControllerFilters.Concat(customActionFilters).OrderBy(i => i).Select(i => i.ConvertToFilterInfo());
        }
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Services.Add(typeof(System.Web.Http.Filters.IFilterProvider), new CustomFilterProvider());
            var providers = configuration.Services.GetFilterProviders();
            var defaultprovider = providers.First(i => i is ActionDescriptorFilterProvider);

            configuration.Services.Remove(typeof(System.Web.Http.Filters.IFilterProvider), defaultprovider);
        }
    }
}