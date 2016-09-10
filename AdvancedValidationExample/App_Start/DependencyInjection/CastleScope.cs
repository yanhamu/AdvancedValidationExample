using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace AdvancedValidationExample.App_Start.DependencyInjection
{
    public class CastleScope : IDependencyScope
    {
        private readonly IWindsorContainer container;
        private readonly IDisposable scope;

        public CastleScope(
            IWindsorContainer container
            )
        {
            this.container = container;
            this.scope = container.BeginScope();
        }

        public void Dispose()
        {
            scope.Dispose();
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