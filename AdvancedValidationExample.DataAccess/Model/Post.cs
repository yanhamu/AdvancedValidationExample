namespace AdvancedValidationExample.DataAccess.Model
{
    public class Post
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public Site Site { get; set; }
        public string Title { get; set; }

        public Post(int id, int siteId, string title)
        {
            this.Id = id;
            this.SiteId = siteId;
            this.Title = title;
        }
    }
}
