using Etherscan.Api.Client.Interfaces;
using RestSharp;

namespace Etherscan.Api.Client
{
    public abstract class ClientBase
    {
        private readonly string _urlApi = "https://api.etherscan.io/api";

        public ClientBase()
        {
            Client = new RestClient(_urlApi);
        }

        public ClientBase(IApiKeyClient apiKey) : this()
        {
            ApiKey = apiKey;
        }

        protected IRestClient Client { get; }

        protected IApiKeyClient ApiKey { get; }
    }
}
