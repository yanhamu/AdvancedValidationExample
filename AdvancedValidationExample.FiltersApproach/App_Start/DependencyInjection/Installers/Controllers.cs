using AdvancedValidationExample.FiltersApproach.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http;

namespace AdvancedValidationExample.FiltersApproach.App_Start.DependencyInjection.Installers
{
    public class Controllers : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes
                    .FromAssemblyContaining<PostController>()
                    .BasedOn<ApiController>()
                    .LifestyleTransient()
                );
        }
    }
}