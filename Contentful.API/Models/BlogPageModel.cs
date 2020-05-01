using System.Collections.Generic;

namespace Contentful.API.Models
{
    using Contentful.Core.Models;
    public class BlogPageModel : BaseModel
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public Asset HeroImage { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string PublishDate { get; set; }
        public string[] Tags { get; set; }
        public string AuthorName { get; set; }
        public string[] Category { get; set; }
    }

    public class Blogs
    {
        public ContentfulCollection<BlogPageModel> BlogList { get; set; }
        public Dictionary<string, int> CategoryCount { get; set; }
    }
}
