using System;
using System.Net;
using Etherscan.Api.Client.Exceptions;
using Etherscan.Api.Client.Responses;
using RestSharp;

namespace Etherscan.Api.Client
{
    public class TokenClient : ClientBase, ITokenClient
    {
        public long GetERC20TokenAccountBalanceForTokenContractAddress(string contractaddress, string address)
        {
            if (string.IsNullOrEmpty(contractaddress))
                throw new ArgumentNullException(nameof(contractaddress));

            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            var url = new UrlBuilder()
                .WithModule(Module.Account)
                .WithAction("tokenbalance")
                .WithContractAddress(contractaddress)
                .WithAddress(address)
                .WithTag("latest")
                .WithApiKey(ApiKey)
                .Build();

            var request = new RestRequest(url, Method.GET);

            var response = Client.Get<ResponseBase<long>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            return response.Data.result;
        }

        public long GetERC20TokenTotalSupplyByContractAddress(string contractaddress)
        {
            if (string.IsNullOrEmpty(contractaddress))
                throw new ArgumentNullException(nameof(contractaddress));

            var url = new UrlBuilder()
                .WithModule(Module.Stats)
                .WithAction("tokensupply")
                .WithContractAddress(contractaddress)
                .WithApiKey(ApiKey)
                .Build();

            var request = new RestRequest(url, Method.GET);

            var response = Client.Get<ResponseBase<long>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            return response.Data.result;
        }
    }
}
