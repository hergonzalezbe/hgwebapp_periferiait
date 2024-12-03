using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace HGWebApp
{
	public class Global : HttpApplication
	{
		// Código que se ejecuta al iniciar la aplicación
		void Application_Start(object sender, EventArgs e)
		{			
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		//Cada vez que se hace un request y se obtiene response
		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			var request = HttpContext.Current.Request;
			var response = HttpContext.Current.Response;

			// Excluir ciertas rutas como Login.aspx o TopTracks.aspx
			if (request.Url.AbsolutePath.Contains("Login.aspx") || request.Url.AbsolutePath.Contains("TopTracks.aspx") ||
				request.Url.AbsolutePath.Contains("Login") || request.Url.AbsolutePath.Contains("TopTracks"))
			{
				return;
			}

			// Validar el token
			if (!SecurityMiddleware.ValidateAccessToken(request))
			{
				// Si el token no es válido, redirigir al login o devolver error
				response.StatusCode = 401;
				response.End();
			}
		}
	}
}