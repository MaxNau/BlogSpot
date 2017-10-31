using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;

namespace BlogSpot.Utils
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer container;

        private IDependencyResolver resolver;

        public UnityDependencyResolver(IUnityContainer container, IDependencyResolver resolver)
        {
            this.container = container;
            this.resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch
            {
                return resolver.GetService(serviceType);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch
            {
                return resolver.GetServices(serviceType);
            }
        }
    }
}
