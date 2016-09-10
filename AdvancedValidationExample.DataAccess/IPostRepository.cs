using AdvancedValidationExample.DataAccess.Model;
using System.Collections.Generic;

namespace AdvancedValidationExample.DataAccess
{
    public interface IPostRepository
    {
        Post GetById(int postId);
        IEnumerable<Post> GetBySiteId(int siteId);
        Post Save(Post post);
        Post Update(Post post);
        Post Remove(Post post);
    }
}
