using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KerridgeTask.Interface;
using Newtonsoft.Json.Linq;

namespace KerridgeTask.Services
{
    public class TokenService : ITokenService
    {
        private readonly HttpClient _httpClient;
        private string _accessToken;
        private DateTime _tokenExpiration;

        public TokenService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetAccessTokenAsync()
        {
            if (_accessToken != null && _tokenExpiration > DateTime.UtcNow)
            {
                return _accessToken;
            }

            var request = new HttpRequestMessage(HttpMethod.Post, ConstParam.identityURL + $"/token");

            var parameters = new Dictionary<string, string>
             {
                 { "client_id", "94eb850d-448f-48ef-a085-5fee4807606e.apps.kerridgecs.com" },
                 { "client_secret", "b609f130-2d13-43d4-93df-f8ab9f1cafde" },
                 { "grant_type", "client_credentials" },
                 { "scope", "eos.common.fullaccess" }
             };

            request.Content = new FormUrlEncodedContent(parameters);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tokenData = JObject.Parse(content);
                _accessToken = tokenData["access_token"]?.ToString();
                var expiresIn = tokenData["expires_in"]?.ToObject<int>() ?? 3600;
                _tokenExpiration = DateTime.UtcNow.AddSeconds(expiresIn);
                return _accessToken;
            }

            return "";
           
        }
    }
}
