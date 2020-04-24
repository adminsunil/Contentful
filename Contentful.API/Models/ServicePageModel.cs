namespace Contentful.API.Models
{
    using Contentful.Core.Models;
    public class ServicePageModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Asset Image { get; set; }
    }
}
