using AdvancedValidationExample.DataAccess;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace AdvancedValidationExample.FiltersApproach.Filters
{
    public class PostExistsAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var postRepository = (IPostRepository)actionContext
                .ControllerContext
                .Configuration
                .DependencyResolver
                .GetService(typeof(IPostRepository));

            if (actionContext.ActionArguments.ContainsKey("postId"))
            {
                var siteId = (int)actionContext.ActionArguments["postId"];

                if (postRepository.GetById(siteId) == null)
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.NotFound);
            }


            base.OnActionExecuting(actionContext);
        }
    }
}