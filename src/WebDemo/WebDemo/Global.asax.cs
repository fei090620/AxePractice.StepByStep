using System;
using System.Web.Http;
using System.Web.Http.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using WebDemo.Controllers;
using WebDemo.Service;

namespace WebDemo
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            InitConfiguration.Init(GlobalConfiguration.Configuration);
        }
    }

    public class InitConfiguration
    {
        public static void Init(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("message", 
                routeTemplate:"MessageController",
                defaults:new
                {
                    controller = "Message",
                    action = "Get"
                });
            var cb = new ContainerBuilder();
            cb.RegisterType<MessageContentService>().InstancePerLifetimeScope();
            cb.RegisterType<MessageController>().InstancePerLifetimeScope();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(cb.Build());
        }
    }
}