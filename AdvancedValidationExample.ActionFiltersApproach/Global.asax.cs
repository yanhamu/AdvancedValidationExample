using AdvancedValidationExample.ActionFiltersApproach.App_Start.DependencyInjection;
using Castle.Windsor;
using System.Web.Http;

namespace AdvancedValidationExample.ActionFiltersApproach
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private IWindsorContainer container;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            container = DiBootstrapper.Bootstrap(GlobalConfiguration.Configuration);
        }
    }
}
