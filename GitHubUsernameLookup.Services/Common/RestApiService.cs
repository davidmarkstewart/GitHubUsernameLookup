using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GitHubUsernameLookup.Services.Common
{
    public class RestApiService
    {
        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "request");
            return client;
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            try
            {
                using (var client = GetHttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(requestUri);

                    return response;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
