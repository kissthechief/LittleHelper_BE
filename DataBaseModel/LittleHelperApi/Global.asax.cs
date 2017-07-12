using AutoMapper;
using LittleHelperApi;
using System.Web.Http;

namespace LittleHelperApi
{
    /// <summary>
    /// Configuration for the wep api
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Things to do at app start
        /// </summary>
        protected void Application_Start()
        {
            UnityConfig.GetConfiguredContainer();

            Mapper.Initialize(c => c.AddProfile<AutoMapperConfig>());

            Mapper.Configuration.AssertConfigurationIsValid();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
