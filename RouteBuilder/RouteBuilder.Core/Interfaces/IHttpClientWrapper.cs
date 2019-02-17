using System.Collections.Generic;

namespace RouteBuilder.Core.Interfaces
{
    public interface IHttpClientWrapper
    {
        string MakeGetRequest(string endpointUri, Dictionary<string, string> requestHeaders);
    }
}