using System.Web;

using Microsoft.Practices.Unity;
using Unity.WebForms;
using WebForms.Services;
using WebFormsProject.Data.Infrastructure;

[assembly: WebActivatorEx.PostApplicationStartMethod( typeof(WebApiWebForms.App_Start.UnityWebFormsStart), "PostStart" )]
namespace WebApiWebForms.App_Start
{
	/// <summary>
	///		Startup class for the Unity.WebForms NuGet package.
	/// </summary>
	internal static class UnityWebFormsStart
	{
		/// <summary>
		///     Initializes the unity container when the application starts up.
		/// </summary>
		/// <remarks>
		///		Do not edit this method. Perform any modifications in the
		///		<see cref="RegisterDependencies" /> method.
		/// </remarks>
		internal static void PostStart()
		{
			IUnityContainer container = new UnityContainer();
			HttpContext.Current.Application.SetContainer( container );

			RegisterDependencies( container );
		}

		/// <summary>
		///		Registers dependencies in the supplied container.
		/// </summary>
		/// <param name="container">Instance of the container to populate.</param>
		private static void RegisterDependencies( IUnityContainer container )
		{
            // TODO: Add any dependencies needed here
            container.RegisterType<IUsuarioService, UsuarioService>();
            container.RegisterType<IProdutoService, ProdutoService>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

        }
	}
}