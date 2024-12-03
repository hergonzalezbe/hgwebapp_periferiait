using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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

                // Aquí puedes validar el token con la API de Spotify
                return ValidateTokenWithSpotify(token);
            }

            private static bool ValidateTokenWithSpotify(string token)
            {
			// Realiza una solicitud a un endpoint de Spotify para validar el token.
			// Por ejemplo, usa RestSharp o HttpClient para llamar al endpoint `/v1/me`.
			// Devuelve true si es válido o false si no lo es.

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
			}
			else
			{
				// Maneja el error
			}

			// Pseudocódigo para ilustrar:
			return !string.IsNullOrEmpty(token); // Sustituye esto por la lógica real
            }        
    }
}