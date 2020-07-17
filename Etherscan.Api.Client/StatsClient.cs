using System;
using System.Collections.Generic;
using System.Net;
using Etherscan.Api.Client.Enums;
using Etherscan.Api.Client.Exceptions;
using Etherscan.Api.Client.Interfaces;
using Etherscan.Api.Client.Mappers;
using Etherscan.Api.Client.Models.Stats;
using Etherscan.Api.Client.Responses;
using Etherscan.Api.Client.Responses.Stats;
using RestSharp;

namespace Etherscan.Api.Client
{
    public class StatsClient : ClientBase, IStatsClient
    {
        public List<EthereumNodesSizeModel> GetEthereumNodesSize(DateTime startdate, DateTime enddate, ClientType clientType, SyncMode syncMode, Sort sort)
        {
            if (startdate == null)
                throw new ArgumentNullException(nameof(startdate));

            if (enddate == null)
                throw new ArgumentNullException(nameof(enddate));

            if (startdate > enddate)
                throw new Exception("TODO"); // todo 

            var url = new UrlBuilder()
                .WithModule(Module.Stats)
                .WithAction("chainsize")
                .WithStartDate(startdate)
                .WithEndDate(enddate)
                .WithClientType(clientType)
                .WithSyncMode(syncMode)
                .WithSort(sort)
                .WithApiKey(ApiKey)
                .Build();

            var request = new RestRequest(url, Method.GET);

            var response = Client.Get<ResponseBase<List<EthereumNodesSizeRespnse>>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            return response.Data.result.ToModels();
        }

        public EtherLastPriceModel GetEtherLastPrice()
        {
            var url = new UrlBuilder()
                .WithModule(Module.Stats)
                .WithAction("ethprice")
                .WithApiKey(ApiKey)
                .Build();

            var request = new RestRequest(url, Method.GET);

            var response = Client.Get<ResponseBase<EtherLastPriceResponse>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            return response.Data.result.ToModel();
        }

        public long GetTotalSupplyOfEther()
        {
            var url = new UrlBuilder()
                .WithModule(Module.Stats)
                .WithAction("ethsupply")
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