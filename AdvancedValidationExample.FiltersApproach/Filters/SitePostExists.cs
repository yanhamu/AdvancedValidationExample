using AdvancedValidationExample.DataAccess;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AdvancedValidationExample.FiltersApproach.Filters
{
    public class SitePostExists : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var postRepository = (IPostRepository)actionContext
                .ControllerContext
                .Configuration
                .DependencyResolver
                .GetService(typeof(IPostRepository));

            if (ContainsArgument(actionContext, "siteId")
                && ContainsArgument(actionContext, "postId"))
            {
                var siteId = (int)actionContext.ActionArguments["siteId"];
                var postId = (int)actionContext.ActionArguments["postId"];

                if (postRepository.GetById(postId).SiteId != siteId)
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            base.OnActionExecuting(actionContext);
        }

        private bool ContainsArgument(HttpActionContext context, string key)
        {
            return context.ActionArguments.ContainsKey(key);
        }
    }
}