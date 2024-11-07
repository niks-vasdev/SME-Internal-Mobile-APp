using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace SmedaInternalMobile.ApiManagers
{
    public class ApiManager : IApiManager
    {
        private readonly HttpClient _httpClient;

        public ApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            return await CallAPI<T>(HttpMethod.Get, uri, null);
        }

        public async Task<T> GetAsync<T>(string uri, object data)
        {
            return await CallAPI<T>(HttpMethod.Get, uri, data);
        }

        public async Task<T> GetAsync<T>(string uri, T data)
        {
            return await CallAPI<T>(HttpMethod.Get, uri, data);
        }

        public async Task<T> PostAsync<T>(string uri, T data)
        {
            return await CallAPI<T>(HttpMethod.Post, uri, data);
        }

        public async Task<T> PostAsync<T>(string uri, object data)
        {
            return await CallAPI<T>(HttpMethod.Post, uri, data);
        }

        public async Task<TR> PostAsync<T, TR>(string uri, T data)
        {
            return await CallAPI<TR>(HttpMethod.Post, uri, data);
        }

        public async Task<T> PutAsync<T>(string uri, object data)
        {
            return await CallAPI<T>(HttpMethod.Put, uri, data);
        }

        public async Task<TR> PutAsync<T, TR>(string uri, T data)
        {
            return await CallAPI<TR>(HttpMethod.Put, uri, data);
        }

        public async Task<T> DeleteAsync<T>(string uri)
        {
            return await CallAPI<T>(HttpMethod.Delete, uri, null);
        }

        public async Task<TR> DeleteAsync<T, TR>(string uri, T data)
        {
            return await CallAPI<TR>(HttpMethod.Delete, uri, data);
        }

        private async Task<T> CallAPI<T>(HttpMethod method, string uri, object data)
        {
            try
            {
                var req = new HttpRequestMessage(method, uri);
                req.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (data != null)
                {
                    req.Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
                }

                string token = Preferences.Get("authToken", null);
                if (!string.IsNullOrEmpty(token))
                {
                    req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var response = await _httpClient.SendAsync(req);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(jsonResult, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                var statusCode = response.StatusCode;
                System.Diagnostics.Debug.WriteLine($"API Call Failed: {statusCode} - {errorContent}");

                throw new ApiException(statusCode, errorContent);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Error in API Call: {e.GetType().Name} : {e.Message}");
                throw;
            }
        }

        public class ApiException : Exception
        {
            public System.Net.HttpStatusCode StatusCode { get; }
            public string Content { get; }

            public ApiException(System.Net.HttpStatusCode statusCode, string content)
                : base($"API call failed with status {statusCode}: {content}")
            {
                StatusCode = statusCode;
                Content = content;
            }
        }
    }
}
