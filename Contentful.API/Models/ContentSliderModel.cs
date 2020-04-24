namespace Contentful.API.Models
{
    using Contentful.Core.Models;
    using Contentful.CodeFirst;

    [ContentType]
    public class ContentSliderModel : BaseModel
    {
        public string Category { get; set; }
        public string HeadingTitle { get; set; }
        public string Description { get; set; }
        public string LinkUrl { get; set; }
        public int Order { get; set; }
        public Asset BannerImage { get; set; }

    }
}
