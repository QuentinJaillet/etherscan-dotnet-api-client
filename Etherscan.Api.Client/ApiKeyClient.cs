using Etherscan.Api.Client.Interfaces;

namespace Etherscan.Api.Client
{
    public class ApiKeyClient : IApiKeyClient
    {
        public ApiKeyClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        public string ApiKey { get; }
    }
}
