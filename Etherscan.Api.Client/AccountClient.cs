using System;
using System.Collections.Generic;
using System.Net;
using Etherscan.Api.Client.Exceptions;
using Etherscan.Api.Client.Models;
using Etherscan.Api.Client.Responses.Account;
using RestSharp;

namespace Etherscan.Api.Client
{
    public class AccountClient : ClientBase, IAccountClient
    {
        public EtherAddressBalanceModel GetEtherBalanceOfAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            var uri = string.Format("?module=account&action=balance&address={0}&tag=latest&apikey={1}", address, ApiKey);

            var request = new RestRequest(uri, Method.GET);

            var response = Client.Get<EtherBalanceResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            return new EtherAddressBalanceModel { Address = address, Balance = response.Data.result };
        }

        public List<EtherAddressBalanceModel> GetEtherBalanceForAddresses(List<string> addresses)
        {
            if (addresses == null)
                throw new ArgumentNullException(nameof(addresses));

            var result = new List<EtherAddressBalanceModel>();

            var uri = string.Format("?module=account&action=balancemulti&address={0}&tag=latest&apikey={1}", string.Join(",", addresses), ApiKey);

            var request = new RestRequest(uri, Method.GET);

            var response = Client.Get<EtherBalanceForAddressesResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            foreach(var res in response.Data.result)
                result.Add(new EtherAddressBalanceModel{ Address = res.account, Balance = res.balance });

            return result;
        }
    }
}
