namespace Contentful.API.Services
{
    using System.Threading.Tasks;
    using Contentful.Core.Models;
    using Contentful.API.Models;
    public interface IHomePageService
    {
        Task<ContentfulCollection<HomePageModel>> GetHomePage();
    }
}
