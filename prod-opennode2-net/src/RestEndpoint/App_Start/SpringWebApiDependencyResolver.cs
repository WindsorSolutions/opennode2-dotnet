using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Web.Http.Dependencies;
using Windsor.Commons.Core;
using System.Collections;

namespace Windsor.OpenNode2.RestEndpoint
{
    public class SpringWebApiDependencyResolver : DisposableBase, IDependencyResolver
    {
        public SpringWebApiDependencyResolver()
        {
        }

        public virtual IDependencyScope BeginScope()
        {
            // This example does not support child scopes, so we simply return 'this'.
            return this;
        }

        public virtual object GetService(Type serviceType)
        {
            object service = null;

            if (serviceType != null)
            {
                if (Init())
                {
                    IDictionary dictionary = ApplicationContext.GetObjectsOfType(serviceType);
                    if (dictionary.Count > 0)
                    {
                        var services = dictionary.GetEnumerator();
                        services.MoveNext();
                        service = services.Value;
                    }
                }
            }

            return service;
        }

        public virtual System.Collections.Generic.IEnumerable<object> GetServices(Type serviceType)
        {
            Init();

            if (serviceType != null)
            {
                if (Init())
                {
                    IDictionary dictionary = ApplicationContext.GetObjectsOfType(serviceType);
                    if (dictionary.Count > 0)
                    {
                        return new List<object>(dictionary.Values.Cast<object>());
                    }
                }
            }

            return new List<object>();
        }

        protected override void OnDispose(bool inIsDisposing)
        {
        }

        protected virtual bool Init()
        {
            try
            {
                if (HttpContext.Current.Request == null)
                {
                    // Spring.Context.Support.ContextRegistry.GetContext() requires HttpContext.Current.Request
                    return false;
                }
            }
            catch (Exception)
            {
                // Spring.Context.Support.ContextRegistry.GetContext() requires HttpContext.Current.Request
                return false;
            }
            if (HttpContext.Current != null)
            {
                if (ApplicationContext == null)
                {
                    lock (s_LockObject)
                    {
                        if (ApplicationContext == null)
                        {
                            try
                            {
                                Spring.Context.IApplicationContext ctx = Spring.Context.Support.ContextRegistry.GetContext();
                                ApplicationContext = ctx;
                            }
                            catch (Exception)
                            {
                                throw;
                            }
                        }
                    }
                }
            }
            return true;
        }
        protected Spring.Context.IApplicationContext ApplicationContext
        {
            get;
            set;
        }
        private static object s_LockObject = new object();
    }
}
