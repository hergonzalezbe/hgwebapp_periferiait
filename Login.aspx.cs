using System;
using System.Configuration;
using System.Web;

namespace HGWebApp
{
	public partial class Login : System.Web.UI.Page
	{	
		private string spotifyClientId, RedirectUri;

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				spotifyClientId = ConfigurationManager.AppSettings["spotifyClientId"];
				RedirectUri = ConfigurationManager.AppSettings["RedirectUri"];

				if (!IsPostBack) { }
			}
			catch (Exception ex)
			{
				Label1.Text = ex.Message;
			}
		}

		protected void btnLogin_Click(object sender, EventArgs e)
		{
			try
			{
				string spotifyAuthUrl = $"https://accounts.spotify.com/authorize?client_id={spotifyClientId}&response_type=code&redirect_uri={HttpUtility.UrlEncode(RedirectUri)}&scope=user-read-private%20user-read-email";
				Response.Redirect(spotifyAuthUrl);
			}
			catch (Exception ex)
			{
				Label1.Text = ex.Message;
			}			
		}
	}
}