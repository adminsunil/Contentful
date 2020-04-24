namespace Contentful.API.Services
{
    using System.Threading.Tasks;
    using Contentful.Core.Models;
    using Contentful.API.Models;
    public interface IServicesPageService
    {
        Task<ContentfulCollection<ServicePageModel>> GetServiceList(int numberOfItems = 0);
    }
}
