using System;
using System.Collections.Generic;
using System.Net.Http;
using RouteBuilder.Core.Interfaces;

namespace RouteBuilder.Core.Implementations
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public string MakeGetRequest(string endpointUri, Dictionary<string, string> requestHeaders)
        {
            string result;
            try
            {
                using (var client = new HttpClient())
                {
                    foreach (var requestHeader in requestHeaders)
                    {
                        client.DefaultRequestHeaders.Add(requestHeader.Key, requestHeader.Value);
                    }

                    var response = client.GetAsync(endpointUri).Result;
                    var responseContent = response.Content;

                    result = responseContent.ReadAsStringAsync().Result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }
    }

}