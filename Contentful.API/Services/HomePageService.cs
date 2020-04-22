using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contentful.API.Configuration;
using Contentful.API.Models;
using Contentful.Core;
using Contentful.Core.Configuration;
using Contentful.Core.Models;
using Contentful.Core.Search;

namespace Contentful.API.Services
{
    public class HomePageService : IHomePageService
    {
        private readonly IContentfulClient _contentfulClient;
       
        public HomePageService(IContentfulClient contentfulClient)
        {
            _contentfulClient = contentfulClient ?? throw new ArgumentNullException(nameof(contentfulClient));
            var httpClient = new HttpClient();
            var contentfulOptions = new ContentfulOptions
            {
                DeliveryApiKey = ContentfulConfiguration.ContentDeliveryKey,
                PreviewApiKey = ContentfulConfiguration.ContentPreviewKey,
                SpaceId = ContentfulConfiguration.SpaceId,
                UsePreviewApi = true,
                MaxNumberOfRateLimitRetries = 2,
            };
            _contentfulClient = new ContentfulClient(httpClient, contentfulOptions);
        }
        public async Task<ContentfulCollection<HomePageModel>> GetHomePage()
        {
            try
            {
                var query = QueryBuilder<HomePageModel>.New.ContentTypeIs(contentTypeId: "homePage");
                //var queryByFields=query.FieldEquals("fields.slug", "soso-wall-clock");
                var result = _contentfulClient.GetEntries(query).Result;
                return await _contentfulClient.GetEntries<HomePageModel>();

            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
