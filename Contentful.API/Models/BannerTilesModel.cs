namespace Contentful.API.Models
{
    using Contentful.Core.Models;
    class BannerTilesModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Asset Image { get; set; }
        public int Order { get; set; }
    }
}
