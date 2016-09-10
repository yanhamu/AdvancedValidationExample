using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Web.Http;

namespace AdvancedValidationExample.ActionFiltersApproach.App_Start.DependencyInjection
{
    public static class DiBootstrapper
    {
        public static IWindsorContainer Bootstrap(HttpConfiguration configuration)
        {
            var container = new WindsorContainer();

            container.Install(FromAssembly.This());
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            configuration.DependencyResolver = new CastleResolver(container);

            return container;
        }
    }
}