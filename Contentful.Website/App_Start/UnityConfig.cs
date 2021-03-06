namespace Contentful.Website
{
    using System.Web.Http;
    using Unity;
    using Unity.WebApi;
    using Contentful.API.Services;
    using Contentful.Core;

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IContentfulClient, ContentfulClient>();
            container.RegisterType<IHomePageService, HomePageService>();
            container.RegisterType<IBlogPageService, BlogPageService>();
            container.RegisterType<IServicesPageService, ServicesPageService>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}