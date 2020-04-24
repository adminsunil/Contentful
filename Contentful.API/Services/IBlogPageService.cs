namespace Contentful.API.Services
{
    using System.Threading.Tasks;
    using Contentful.Core.Models;
    using Contentful.API.Models;
    public interface IBlogPageService
    {
        Task<ContentfulCollection<BlogPageModel>> GetBlogList(int numberOfItems = 0);
        Task<BlogPageModel> GetBlogDetail(string slug);

    }
}
