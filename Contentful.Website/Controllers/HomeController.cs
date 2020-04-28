using System.Linq;

namespace Contentful.Website.Controllers
{
  using System;
  using System.Threading.Tasks;
  using System.Web.Http;
  using System.Web.Http.Cors;
  using Contentful.API.Services;

  [RoutePrefix("contentful")]
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class HomeController : ApiController
  {
    private readonly IHomePageService _homePageService;
    private readonly IBlogPageService _blogPageService;
    private readonly IServicesPageService _servicesPageService;
    public HomeController(IHomePageService homePageService, IBlogPageService blogPageService, IServicesPageService servicesPageService)
    {
      _homePageService = homePageService ?? throw new ArgumentNullException(nameof(homePageService));
      _blogPageService = blogPageService ?? throw new ArgumentNullException(nameof(blogPageService));
      _servicesPageService = servicesPageService ?? throw new ArgumentNullException(nameof(servicesPageService));
    }

    [Route("home-page")]
    [HttpGet]
    public async Task<IHttpActionResult> HomePage()
    {
      var homePage = await _homePageService.GetHomePage();
      return Ok(homePage);
    }

    [Route("blog-page")]
    [HttpGet]
    public async Task<IHttpActionResult> BlogPage()
    {
      var blogList = await _blogPageService.GetBlogList();
      return Ok(blogList);
    }

    [Route("blog-detail")]
    [HttpGet]
    public async Task<IHttpActionResult> BlogDetail(string slug)
    {
      var blogDetail = await _blogPageService.GetBlogDetail(slug);
      return Ok(blogDetail);
    }

    [Route("services-page")]
    [HttpGet]
    public async Task<IHttpActionResult> ServicesPage()
    {
      var serviceList = await _servicesPageService.GetServiceList();
      return Ok(serviceList);
    }
  }
}
