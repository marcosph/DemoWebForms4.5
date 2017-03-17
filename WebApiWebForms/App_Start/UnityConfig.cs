using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WebForms.Services;
using WebFormsProject.Data;
using WebFormsProject.Data.Infrastructure;
using WebFormsProject.Data.Repository;

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
            container.RegisterType<IProdutoService, ProdutoService>();

            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Produto>, IRepository<Produto>>();
            container.RegisterType<IProdutoRepository, ProdutoRepository>();
            


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}