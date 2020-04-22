namespace Contentful.API.Configuration
{
    public class ContentfulConfiguration : BaseConfiguration
    {
        public static string SpaceId => (string)GetAppSetting("SpaceId");
        public static string ContentDeliveryKey => (string)GetAppSetting("ContentDeliveryKey");
        public static string ContentPreviewKey => (string)GetAppSetting("ContentPreviewKey");
        public static string StaggingEnvironment => (string)GetAppSetting("StaggingEnvironment");
        public static string MasterEnvironment => (string)GetAppSetting("MasterEnvironment");
    }
}
