namespace Contentful.API.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Contentful.API.Configuration;
    using Contentful.API.Models;
    using Contentful.Core;
    using Contentful.Core.Models;
    using Contentful.Core.Search;

    public class HomePageService : ContentfulConfiguration, IHomePageService
    {
        private readonly IContentfulClient _contentfulClient;

        public HomePageService(IContentfulClient contentfulClient)
        {
            _contentfulClient = contentfulClient ?? throw new ArgumentNullException(nameof(contentfulClient));
            var httpClient = new HttpClient();
            _contentfulClient = new ContentfulClient(httpClient, GetContentfulOptions());
        }
        public async Task<ContentfulCollection<HomePageModel>> GetHomePage()
        {
            try
            {
                var query = QueryBuilder<HomePageModel>.New.ContentTypeIs(contentTypeId: HomeContentModelId);
                //var queryByFields=query.FieldEquals("fields.slug", "soso-wall-clock");
                var result = _contentfulClient.GetEntries(query);
                return await result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
