using System.Collections.Generic;
using System.Threading.Tasks;

namespace RouteBuilder.Core.Interfaces
{
    public interface IHttpClientWrapper
    {
        Task<string> MakeGetRequest(string endpointUri, Dictionary<string, string> requestHeaders);
    }
}