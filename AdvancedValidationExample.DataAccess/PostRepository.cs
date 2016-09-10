using AdvancedValidationExample.DataAccess.Model;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedValidationExample.DataAccess
{
    public class PostRepository : IPostRepository
    {
        private readonly List<Post> posts;

        public PostRepository()
        {
            this.posts = new List<Post>()
            {
                new Post(1,1,"About Food"),
                new Post(2,1,"My Second humble post"),
                new Post(3,2,"About velvet locomotives")
            };
        }

        public Post GetById(int postId)
        {
            return posts.SingleOrDefault(p => p.Id == postId);
        }

        public IEnumerable<Post> GetBySiteId(int siteId)
        {
            return posts.Where(p => p.SiteId == siteId).ToList();
        }

        public Post Remove(Post post)
        {
            return posts.Remove(post) ? post : null;
        }

        public Post Save(Post post)
        {
            posts.Add(post);
            return post;
        }

        public Post Update(Post post)
        {
            var toUpdate = posts.Single(p => p.Id == post.Id);
            toUpdate.Title = post.Title;
            return toUpdate;
        }
    }
}
