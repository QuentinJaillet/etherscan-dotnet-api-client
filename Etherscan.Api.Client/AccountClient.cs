using System;
using System.Collections.Generic;
using System.Net;
using Etherscan.Api.Client.Enums;
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

            foreach (var res in response.Data.result)
                result.Add(new EtherAddressBalanceModel { Address = res.account, Balance = res.balance });

            return result;
        }

        public List<TransactionModel> GetNormalTransactionsOfAddress(string address, Sort sort = Sort.Asc, int startblock = 0, int endblock = 99999999)
        {
            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            // todo startblock
            // todo endblock

            var result = new List<TransactionModel>();

            var sortValue = sort == Sort.Asc ? "asc" : "desc";

            var uri = string.Format("?module=account&action=txlist&address={0}&startblock={1}&endblock={2}&sort={3}&apikey={4}", address, startblock, endblock, sortValue, ApiKey);

            var request = new RestRequest(uri, Method.GET);

            var response = Client.Get<NormalTransactionsResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new ResponseException(response.ErrorMessage, response.ErrorException);

            foreach (var res in response.Data.result)
                result.Add(ConvertToTransactionModel(res));

            return result;
        }

        private static TransactionModel ConvertToTransactionModel(NormalTransactionResponse response)
        {
            return new TransactionModel
            {
                BlockHash = response.blockHash,
                BlockNumber = response.blockNumber,
                Confirmations = response.confirmations,
                ContractAddress = response.contractAddress,
                CumulativeGasUsed = response.cumulativeGasUsed,
                From = response.from,
                Gas = response.gas,
                GasPrice = response.gasPrice,
                GasUsed = response.gasUsed,
                Hash = response.hash,
                Input = response.input,
                IsError = response.isError,
                Nonce = response.nonce,
                TimeStamp = response.timeStamp,
                To = response.to,
                TransactionIndex = response.transactionIndex,
                TxReceiptStatus = response.txreceipt_status,
                Value = response.value
            };
        }
    }
}
