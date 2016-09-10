using AdvancedValidationExample.ActionFiltersApproach.Controllers;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http;

namespace AdvancedValidationExample.ActionFiltersApproach.App_Start.DependencyInjection.Installers
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