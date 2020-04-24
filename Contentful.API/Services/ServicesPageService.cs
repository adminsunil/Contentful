namespace Contentful.API.Services
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Contentful.API.Configuration;
    using Contentful.API.Models;
    using Contentful.Core;
    using Contentful.Core.Models;
    using Contentful.Core.Search;

    public class ServicesPageService : ContentfulConfiguration, IServicesPageService
    {
        private readonly IContentfulClient _contentfulClient;

        public ServicesPageService(IContentfulClient contentfulClient)
        {
            _contentfulClient = contentfulClient ?? throw new ArgumentNullException(nameof(contentfulClient));
            var httpClient = new HttpClient();
            _contentfulClient = new ContentfulClient(httpClient, GetContentfulOptions());
        }

        public async Task<ContentfulCollection<ServicePageModel>> GetServiceList(int numberOfItems = 0)
        {
            try
            {
                var query = QueryBuilder<ServicePageModel>.New.ContentTypeIs(contentTypeId: ServiceContentModelId);
                if (numberOfItems != 0)
                {
                    query = query.Limit(numberOfItems);
                }
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
