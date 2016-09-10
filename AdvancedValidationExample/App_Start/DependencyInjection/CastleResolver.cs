using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace AdvancedValidationExample.App_Start.DependencyInjection
{
    public class CastleResolver : IDependencyResolver
    {
        private readonly IWindsorContainer container;

        public CastleResolver(IWindsorContainer container)
        {
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new CastleScope(container);
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            return container.Kernel.HasComponent(serviceType) ? container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType).Cast<object>();
        }
    }
}