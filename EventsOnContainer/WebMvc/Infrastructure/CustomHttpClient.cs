using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient _client;
        public CustomHttpClient()
        {
            _client = new HttpClient();
        }
        public async Task<string> GetStringAsync(string uri,
            string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod, authorizationToken);

            }
            var response = await _client.SendAsync(requestMessage); ;
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> DeleteAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            if (authorizationToken != null)
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod, authorizationToken);

            }
            
            return await _client.SendAsync(requestMessage);
        }



        public async Task<HttpResponseMessage> PostAsync<T>(string uri, T item, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            return await DoPutPostAsync(HttpMethod.Post, uri, item, authorizationToken, authorizationMethod);
        }

        public async Task<HttpResponseMessage> PutAsync<T>(string uri, T item, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            return await DoPutPostAsync(HttpMethod.Put, uri, item, authorizationToken, authorizationMethod);
        }

        public async Task<HttpResponseMessage> DoPutPostAsync<T>(HttpMethod method,string uri, T item, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            if(method != HttpMethod.Put && method != HttpMethod.Post)
            {
                throw new ArgumentException("Value must be either put or post.", nameof(method));
            }
            var httpRequest = new HttpRequestMessage(method, uri);
            httpRequest.Content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            if(authorizationToken != null)
            {
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue(authorizationMethod, authorizationToken);
                    
            }
            var response =  await _client.SendAsync(httpRequest);
            if(response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException();
            }
            return response;
        }
    }
}
