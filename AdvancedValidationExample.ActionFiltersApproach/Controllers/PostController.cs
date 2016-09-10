using AdvancedValidationExample.DataAccess;
using AdvancedValidationExample.DataAccess.Model;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdvancedValidationExample.ActionFiltersApproach.Controllers
{
    [RoutePrefix("api/sites/{siteId:int}/posts")]
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
            if (siteRepository.GetById(siteId) == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, repository.GetBySiteId(siteId));
        }

        [Route("{postId:int}")]
        [HttpGet]
        public HttpResponseMessage Get(int postId, int siteId)
        {
            var post = repository.GetById(postId);

            if (post == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            if (post.SiteId != siteId)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

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
        public HttpResponseMessage Put(int siteId, int postId, [FromBody]Post post)
        {
            if (post.SiteId != siteId)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (post.Id != postId)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var existingPost = repository.GetById(postId);
            if (existingPost == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);

            if (existingPost.SiteId != siteId)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            return Request.CreateResponse(HttpStatusCode.OK, repository.Update(post));
        }

        [Route("{postId:int}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int siteId, int postId)
        {
            var post = repository.GetById(postId);

            if (post == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            if (post.SiteId != siteId)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            var removed = repository.Remove(post);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}