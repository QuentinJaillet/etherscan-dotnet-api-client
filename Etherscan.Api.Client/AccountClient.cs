using System;
using System.Net;
using Etherscan.Api.Client.Exceptions;
using Etherscan.Api.Client.Models.Account;
using RestSharp;

namespace Etherscan.Api.Client
{
    public class AccountClient : ClientBase, IAccountClient
    {
        public int GetEtherBalanceOfAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            var uri = string.Format("?module=account&action=balance&address={0}&tag=latest&apikey={1}", address, ApiKey);

            var request = new RestRequest(uri, Method.GET);

            var response = Client.Get<EtherBalanceByAddressResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            var data = response.Data;
            return data.result;
        }
    }
}
