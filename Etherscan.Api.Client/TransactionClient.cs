using System;
using System.Net;
using Etherscan.Api.Client.Exceptions;
using Etherscan.Api.Client.Interfaces;
using Etherscan.Api.Client.Models.Transaction;
using Etherscan.Api.Client.Responses;
using Etherscan.Api.Client.Responses.Transaction;
using RestSharp;

namespace Etherscan.Api.Client
{
    public class TransactionClient : ClientBase, ITransactionClient
    {
        public TransactionClient() : base()
        {
        }

        public TransactionClient(IApiKeyClient apiKey) : base(apiKey)
        {
        }

        public ContractExecutionStatusModel CheckContractExecutionStatus(string txhash)
        {
            if (string.IsNullOrEmpty(txhash))
                throw new ArgumentNullException(nameof(txhash));

            var url = new UrlBuilder()
                .WithModule(Module.Transaction)
                .WithAction("getstatus")
                .WithTransactionHash(txhash)
                .AndAddApiKey(ApiKey)
                .Build();

            var request = new RestRequest(url, Method.GET);

            var response = Client.Get<ResponseBase<ContractExecutionStatusResponse>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            return new ContractExecutionStatusModel { IsError = response.Data.result.isError, ErrDescription = response.Data.result.errDescription };
        }

        public TransactionReceiptStatusModel CheckTransactionReceiptStatus(string txhash)
        {
            if (string.IsNullOrEmpty(txhash))
                throw new ArgumentNullException(nameof(txhash));

            var url = new UrlBuilder()
                .WithModule(Module.Transaction)
                .WithAction("gettxreceiptstatus")
                .WithTransactionHash(txhash)
                .AndAddApiKey(ApiKey)
                .Build();

            var request = new RestRequest(url, Method.GET);

            var response = Client.Get<ResponseBase<TransactionReceiptStatusResponse>>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            return new TransactionReceiptStatusModel { Status = response.Data.result.status == 0 ? false : true };
        }
    }
}
