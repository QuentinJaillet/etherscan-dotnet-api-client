using System.Net;
using Etherscan.Api.Client.Exceptions;
using Etherscan.Api.Client.Interfaces;
using Etherscan.Api.Client.Mappers;
using Etherscan.Api.Client.Models.GasTracker;
using Etherscan.Api.Client.Responses;
using Etherscan.Api.Client.Responses.GasTracker;
using RestSharp;

namespace Etherscan.Api.Client
{
    public class GasTrackerClient : ClientBase, IGasTrackerClient
    {
        public int GetEstimationOfConfirmationTime(long gasprice)
        {
            var url = new UrlBuilder()
                .WithModule(Module.GasTracker)
                .WithAction("gasestimate")
                .WithGasPrice(gasprice)
                .WithApiKey(ApiKey)
                .Build();

            var request = new RestRequest(url, Method.GET);

            var response = Client.Get<ResponseBase<int>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            return response.Data.result;
        }

        public GasOracleModel GetGasOracle()
        {
            var url = new UrlBuilder()
                .WithModule(Module.GasTracker)
                .WithAction("gasoracle")
                .WithApiKey(ApiKey)
                .Build();

            var request = new RestRequest(url, Method.GET);

            var response = Client.Get<ResponseBase<GasOracleResponse>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            return response.Data.result.ToModel();
        }
    }
}