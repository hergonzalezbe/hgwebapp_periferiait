using RestSharp;
using System.Web;

namespace HGWebApp
{
	public class SecurityMiddleware
	{
        
            public static bool ValidateAccessToken(HttpRequest request)
            {
                string token = request.Headers["Authorization"];

                if (string.IsNullOrEmpty(token) || !token.StartsWith("Bearer "))
                {
                    return false;
                }

                token = token.Replace("Bearer ", "");

                // Se valida el token
                return ValidateTokenWithSpotify(token);
            }

		private static bool ValidateTokenWithSpotify(string token)
		{
			// Se hace un request a un endpoint para validar el token 			
			// Devuelve true si es válido.

			//LLamar algún endpoint
			var client = new RestClient("https://api.spotify.com");
			var request = new RestRequest("/v1/me");
			request.Method = Method.Get;
			request.AddHeader("Authorization", "Bearer " + token);

			var response = client.Execute(request);
			if (response.IsSuccessful)
			{
				var userProfile = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response.Content);
				// Procesa los datos del perfil del usuario
				return true;
			}
			else
			{
				return false;
			}
		}        
    }
}