using Microsoft.Practices.Unity;
using System.Web.Http;
using System.Web.Mvc;
using Unity.WebApi;
using WebForms.Services;
using WebFormsEmpty.Controllers;
using WebFormsProject.Data;
using WebFormsProject.Data.Infrastructure;
using WebFormsProject.Data.Repository;

namespace WebFormsEmpty
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IUsuarioService, UsuarioService>();
            container.RegisterType<IProdutoService, ProdutoService>();
            

            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Produto>, IRepository<Produto>>();
            container.RegisterType<IProdutoRepository, ProdutoRepository>();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            // GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}