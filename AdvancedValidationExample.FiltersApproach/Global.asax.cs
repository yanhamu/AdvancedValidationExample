using AdvancedValidationExample.FiltersApproach.App_Start.DependencyInjection;
using Castle.Windsor;
using System.Web.Http;

namespace AdvancedValidationExample.FiltersApproach
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IWindsorContainer container;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            container = DIBootstrapper.Bootstrap(GlobalConfiguration.Configuration);
        }
    }
}
