using AdvancedValidationExample.DataAccess;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AdvancedValidationExample.FiltersApproach.Filters
{
    public class SiteFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var siteRepository = (ISiteRepository)actionContext
                .ControllerContext
                .Configuration
                .DependencyResolver
                .GetService(typeof(ISiteRepository));

            if (actionContext.ActionArguments.ContainsKey("siteId"))
            {
                var siteId = (int)actionContext.ActionArguments["siteId"];

                if (siteRepository.GetById(siteId) == null)
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            base.OnActionExecuting(actionContext);
        }
    }
}