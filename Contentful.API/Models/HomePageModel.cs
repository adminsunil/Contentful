namespace Contentful.API.Models
{
    using System.Collections.Generic;

    public class HomePageModel: BaseModel
    {
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string CopyrightText { get; set; }
        public List<ContentSliderModel> ContentSlider { get; set; }
        public List<BannerTilesModel> BannerTiles { get; set; }
    }
}
