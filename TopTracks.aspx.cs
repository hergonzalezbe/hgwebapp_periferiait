using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Configuration;
using System.Web.UI;

namespace HGWebApp
{
	public partial class TopTracks : System.Web.UI.Page
	{   
        private string spotifyClientId,ClientSecret, RedirectUri;

        private static string token = null;
        private static DateTime tokenExpiration = DateTime.MinValue;
        protected void Page_Load(object sender, EventArgs e)
		{
            spotifyClientId = ConfigurationManager.AppSettings["spotifyClientId"];
            ClientSecret = ConfigurationManager.AppSettings["spotifyClientSecret"];            
            RedirectUri = ConfigurationManager.AppSettings["RedirectUri"];

            string code = Request.QueryString["code"];
            token = Session["token"]!=null? Session["token"].ToString(): string.Empty;

            if (!string.IsNullOrEmpty(code))
            {   
                if (string.IsNullOrEmpty(token) || DateTime.Now >= tokenExpiration)
                {
                    token = getToken(code);
                    Session["token"] = token;
                }
                
                if (!string.IsNullOrEmpty(token))
                {
                    //lblResult.Text = "Access token obtenido correctamente: " + token;
                    spotifyRequest(token);
                }
                else
                {
                    lblResult.Text = "Error al obtener el token.";
                }
            }
            else
            {
                lblResult.Text = "No se recibió ningún código de autorización.";
            }
        }

        private string getToken(string code)
        {
            var client = new RestClient("https://accounts.spotify.com/api/token");            
            var request = new RestRequest(); 
            request.Method = Method.Post; 
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "authorization_code");
            request.AddParameter("code", code);
            request.AddParameter("redirect_uri", RedirectUri);
            request.AddParameter("client_id", spotifyClientId);
            request.AddParameter("client_secret", ClientSecret);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                var json = JObject.Parse(response.Content);                
                tokenExpiration = DateTime.Now.AddSeconds(Convert.ToInt32(json["expires_in"]));
                return json["access_token"]?.ToString();
            }
            return null;
        }

        private void spotifyRequest(string token)
		{
            //string artistId = "43ZHCT0cAZBISjO8DG9PnE"; //Presley
            //string artistId = "4STHEaNw4mPZ2tzheohgXB"; //McCartney
            string artistId = "6SPpCqM8gOzrtICAxN5NuX"; // tito puente

            string market = "US";

            var client = new RestClient($"https://api.spotify.com/v1/artists/{artistId}/top-tracks?market={market}");
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Authorization", "Bearer " + token);

            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                // Token expirado, refrescar y reintentar
                token = refreshToken();
                if (!string.IsNullOrEmpty(token))
                {
                    spotifyRequest(token); // Reintentar con el nuevo token
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Error al refrescar el token.");
                }
            }
            else if (response.IsSuccessful)
            {
                //System.Diagnostics.Debug.WriteLine("Canciones populares: " + response.Content);                
                string jsonResponse = response.Content.Replace("\"", "\\\"");

                // Inyectar el JSON en el cliente
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LoadData",
                    $"var data = JSON.parse(\"{jsonResponse}\");", true);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Error: " + response.Content);
            }
        }

        // Refrescar token
        private string refreshToken()
        {
            var client = new RestClient("https://accounts.spotify.com/api/token");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "refresh_token");
            request.AddParameter("refresh_token", token); 
            request.AddParameter("client_id", spotifyClientId);
            request.AddParameter("client_secret", ClientSecret);

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
                tokenExpiration = DateTime.UtcNow.AddSeconds((int)json.expires_in);
                return json.access_token;
            }

            return null;
        }
    }
}