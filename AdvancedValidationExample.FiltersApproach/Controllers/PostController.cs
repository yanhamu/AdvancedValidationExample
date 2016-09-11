using AdvancedValidationExample.DataAccess;
using AdvancedValidationExample.DataAccess.Model;
using AdvancedValidationExample.FiltersApproach.Filters;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdvancedValidationExample.FiltersApproach.Controllers
{
    [RoutePrefix("api/sites/{siteId}/posts")]
    [SiteExists]
    public class PostController : ApiController
    {
        private readonly IPostRepository repository;
        private readonly ISiteRepository siteRepository;

        public PostController(ISiteRepository siteRepository, IPostRepository postRepository)
        {
            this.siteRepository = siteRepository;
            this.repository = postRepository;
        }

        [Route]
        [HttpGet]
        public HttpResponseMessage Get(int siteId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, repository.GetBySiteId(siteId));
        }

        [Route("{postId:int}")]
        [HttpGet]
        [PostExists]
        [SitePostExists]
        public HttpResponseMessage Get(int postId, int siteId)
        {
            var post = repository.GetById(postId);
            return Request.CreateResponse(HttpStatusCode.OK, post);
        }

        [Route]
        [HttpPost]
        public HttpResponseMessage Post(int siteId, [FromBody] Post post)
        {
            if (post.SiteId != siteId)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK, repository.Save(post));
        }

        [Route("{postId:int}")]
        [HttpPut]
        [PostExists]
        [SitePostExists]
        public HttpResponseMessage Put(int siteId, int postId, [FromBody]Post post)
        {
            if (post.SiteId != siteId || postId != post.Id)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK, repository.Update(post));
        }

        [Route("{postId:int}")]
        [HttpDelete]
        [PostExists]
        [SitePostExists]
        public HttpResponseMessage Delete(int siteId, int postId)
        {
            var post = repository.GetById(postId);
            var removed = repository.Remove(post);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}