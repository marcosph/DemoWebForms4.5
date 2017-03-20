using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Unity.WebApi;
using WebForms.Services;
using WebFormsProject.Data;
using WebFormsProject.Data.Infrastructure;
using WebFormsProject.Data.Repository;

namespace WebFormsEmpty.App_Start
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            var containerClassic = BuildUnityContainerClassic();

            DependencyResolver.SetResolver(new UnityDependencyResolver(containerClassic));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }


        private static IUnityContainer BuildUnityContainerClassic()
        {
            var container = new UnityContainer();
            container.RegisterType<IUsuarioService, UsuarioService>();
            container.RegisterType<IProdutoService, ProdutoService>();

            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Produto>, IRepository<Produto>>();
            container.RegisterType<IProdutoRepository, ProdutoRepository>();


            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            container.RegisterType<IUsuarioService, UsuarioService>();
            container.RegisterType<IProdutoService, ProdutoService>();

            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Produto>, IRepository<Produto>>();
            container.RegisterType<IProdutoRepository, ProdutoRepository>();


            return container;
        }
    }

    public class ControllerActivator : IControllerActivator
    {
        IController IControllerActivator.Create(RequestContext requestContext, Type controllerType)
        {
            return GlobalConfiguration.Configuration.DependencyResolver.GetService(controllerType) as IController;
        }
    }




}