using RestSharp;

namespace Etherscan.Api.Client
{
    public class ClientBase
    {
        private readonly string _urlApi = "https://api.etherscan.io/api";

        public ClientBase()
        {
            Client = new RestClient(_urlApi);
        }

        public ClientBase(string apiKey) : base()
        {
            ApiKey = apiKey;
        }

        protected IRestClient Client { get; }

        protected string ApiKey { get; }
    }
}
