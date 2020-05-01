

namespace Contentful.API.Services
{
    using Contentful.API.Configuration;
    using Contentful.API.Models;
    using Contentful.Core;
    using Contentful.Core.Search;
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class HomePageService : ContentfulConfiguration, IHomePageService
    {
        private readonly IContentfulClient _contentfulClient;

        public HomePageService(IContentfulClient contentfulClient)
        {
            _contentfulClient = contentfulClient ?? throw new ArgumentNullException(nameof(contentfulClient));
            var httpClient = new HttpClient();
            _contentfulClient = new ContentfulClient(httpClient, GetContentfulOptions());
        }
        public async Task<HomePageModel> GetHomePage()
        {
            try
            {
                var query = QueryBuilder<HomePageModel>.New.ContentTypeIs(contentTypeId: HomeContentModelId);
                var result = await _contentfulClient.GetEntries(query);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
