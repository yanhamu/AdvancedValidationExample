using AdvancedValidationExample.DataAccess;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace AdvancedValidationExample.App_Start.DependencyInjection.Installers
{
    public class Repositories : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(Classes
                    .FromAssemblyContaining<IPostRepository>()
                    .Where(t => t.Name.EndsWith("Repository"))
                    .WithServiceDefaultInterfaces()
                    .LifestyleTransient());
        }
    }
}