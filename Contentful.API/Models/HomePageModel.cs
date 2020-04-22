namespace Contentful.API.Models
{
    using System.Collections.Generic;
    using Contentful.Core.Models;
    public class HomePageModel: BaseModel
    {
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string CopyrightText { get; set; }
        public List<Asset> ContentSlider { get; set; }
        public List<Asset> BannerTiles { get; set; }
    }
}
