using Contentful.Core.Configuration;

namespace Contentful.API.Configuration
{
    public class ContentfulConfiguration : BaseConfiguration
    {
        public ContentfulOptions GetContentfulOptions()
        {
            return new ContentfulOptions
            {
                DeliveryApiKey = ContentDeliveryKey,
                PreviewApiKey = ContentPreviewKey,
                SpaceId = SpaceId,
                UsePreviewApi = true,
                MaxNumberOfRateLimitRetries = 2,
            };
        }

        public static string SpaceId => (string)GetAppSetting("SpaceId");
        public static string ContentDeliveryKey => (string)GetAppSetting("ContentDeliveryKey");
        public static string ContentPreviewKey => (string)GetAppSetting("ContentPreviewKey");
        public static string StaggingEnvironment => (string)GetAppSetting("StaggingEnvironment");
        public static string MasterEnvironment => (string)GetAppSetting("MasterEnvironment");
        public static string BlogContentModelId = "blogPost";
        public static string HomeContentModelId = "homePage";
        public static string ServiceContentModelId = "services";
    }
}
