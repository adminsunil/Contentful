namespace Contentful.API.Services
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Contentful.API.Configuration;
    using Contentful.API.Models;
    using Contentful.Core;
    using Contentful.Core.Models;
    using Contentful.Core.Search;

    public class BlogPageService : ContentfulConfiguration, IBlogPageService
    {
        private readonly IContentfulClient _contentfulClient;

        public BlogPageService(IContentfulClient contentfulClient)
        {
            _contentfulClient = contentfulClient ?? throw new ArgumentNullException(nameof(contentfulClient));
            var httpClient = new HttpClient();
            _contentfulClient = new ContentfulClient(httpClient, GetContentfulOptions());
        }
        public async Task<ContentfulCollection<BlogPageModel>> GetBlogList(int pageNumber, int numberOfItems = 0)
        {
            try
            {
                var query = QueryBuilder<BlogPageModel>.New.ContentTypeIs(contentTypeId: BlogContentModelId);
                if (numberOfItems == 0)
                {
                    numberOfItems = 10;
                }

                query = query.Skip((pageNumber - 1) * numberOfItems).Limit(numberOfItems);

                var result = _contentfulClient.GetEntries(query);
                return await result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



        public async Task<Dictionary<string, int>> GetCategoryCount()
        {
            var query = QueryBuilder<BlogPageModel>.New.ContentTypeIs(contentTypeId: BlogContentModelId);

            var entries = await _contentfulClient.GetEntries(query);

            var categoryCount= entries
                .GroupBy(x => x.Category)
                .SelectMany(x => x.Key)
                .GroupBy(x => x)
                .Select(x => new { category = x.Key, count = x.Count() });

            return categoryCount.ToDictionary(x => x.category, x => x.count);
        }

        public async Task<BlogPageModel> GetBlogDetail(string slug)
        {
            try
            {
                var query = QueryBuilder<BlogPageModel>.New.ContentTypeIs(contentTypeId: BlogContentModelId);
                query = query.FieldEquals("fields.slug", slug);
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
