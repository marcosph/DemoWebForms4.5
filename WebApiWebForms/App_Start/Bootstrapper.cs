using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace WebApiWebForms.App_Start
{
    public static class Bootstrapper
    {
        #region Initialize
        public static void Initialize()
        {
            IUnityContainer container = BuildUnityContainer();
            DependencyResolver.SetResolver(new MyUnityDependencyResolver(container));
        }
        #endregion

        #region BuildUnityContainer (private)
        private static IUnityContainer BuildUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            // container.RegisterType<IMoninterface, MaClasse>();

            return container;
        }
        #endregion
    }

    public sealed class MyUnityDependencyResolver : IDependencyResolver
    {
        public MyUnityDependencyResolver(IUnityContainer conteneur)
        {
            _conteneur = conteneur;
        }
        IUnityContainer _conteneur;

        public object GetService(Type serviceType)
        {
            try
            {
                return _conteneur.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _conteneur.ResolveAll(serviceType);
            }
            catch
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}