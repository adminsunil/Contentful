using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Contentful.API.Services;

namespace Contentful.Website.Controllers
{
    [RoutePrefix("contentful")]
    public class HomeController : ApiController
    {
        private readonly IHomePageService _homePageService;
        public HomeController(IHomePageService homePageService)
        {
            _homePageService = homePageService ?? throw new ArgumentNullException(nameof(homePageService));
        }
        [Route("home-page")]
        [HttpGet]
        public async Task<IHttpActionResult> HomePage()
        {
            var homePage = _homePageService.GetHomePage().Result;
            return Ok(homePage);
        }
    }
}
