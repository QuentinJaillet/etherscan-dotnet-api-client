using System;
using System.Net;
using Etherscan.Api.Client.Exceptions;
using Etherscan.Api.Client.Mappers;
using Etherscan.Api.Client.Models.Transaction;
using Etherscan.Api.Client.Responses;
using Etherscan.Api.Client.Responses.Block;
using RestSharp;

namespace Etherscan.Api.Client
{
    public class BlockClient : ClientBase, IBlockClient
    {
        public BlockAndUncleRewardsModel GetBlockAndUncleRewardsbyBlockNo(string blockNo)
        {
            if (string.IsNullOrEmpty(blockNo))
                throw new ArgumentNullException(nameof(blockNo));

            var url = new UrlBuilder()
                .WithModule(Module.Block)
                .WithAction("getblockreward")
                .WithBlockNo(blockNo)
                .WithApiKey(ApiKey)
                .Build();

            var request = new RestRequest(url, Method.GET);

            var response = Client.Get<ResponseBase<BlockAndUncleRewardsResponse>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            return response.Data.result.ToModel();
        }

        public void GetBlockNumberbyTimestamp()
        {
            throw new System.NotImplementedException();
        }

        public EstimatedBlockCountdownTimeModel GetEstimatedBlockCountdownTimebyBlockNo(string blockNo)
        {
            if (string.IsNullOrEmpty(blockNo))
                throw new ArgumentNullException(nameof(blockNo));

            var url = new UrlBuilder()
                .WithModule(Module.Block)
                .WithAction("getblockcountdown")
                .WithBlockNo(blockNo)
                .WithApiKey(ApiKey)
                .Build();

            var request = new RestRequest(url, Method.GET);

            var response = Client.Get<ResponseBase<EstimatedBlockCountdownTimeResponse>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            return response.Data.result.ToModel();
        }
    }
}
