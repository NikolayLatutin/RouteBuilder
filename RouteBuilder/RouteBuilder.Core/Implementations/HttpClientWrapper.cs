using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RouteBuilder.Core.Interfaces;

namespace RouteBuilder.Core.Implementations
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public async Task<string> MakeGetRequest(string endpointUri, Dictionary<string, string> requestHeaders)
        {
            string result;
            using (var client = new HttpClient())
            {
                foreach (var requestHeader in requestHeaders)
                {
                    client.DefaultRequestHeaders.Add(requestHeader.Key, requestHeader.Value);
                }
                    
                var response = await client.GetAsync(endpointUri);
                var responseContent = response.Content;

                result = await responseContent.ReadAsStringAsync();
            }
            return result;
        }
    }

}