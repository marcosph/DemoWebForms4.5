using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WebForms.Services;
using WebFormsProject.Data.Infrastructure;

namespace WebApiWebForms
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUsuarioService,UsuarioService>();

            container.RegisterType<IDatabaseFactory, DatabaseFactory>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}