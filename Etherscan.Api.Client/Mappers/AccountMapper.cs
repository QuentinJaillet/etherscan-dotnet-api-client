using Etherscan.Api.Client.Models;
using Etherscan.Api.Client.Responses.Account;

namespace Etherscan.Api.Client.Mappers
{
    internal static class AccountMapper
    {
        public static EtherAddressBalanceModel ToModel(this int balance, string address)
        {
            return new EtherAddressBalanceModel { Address = address, Balance = balance };
        }

        public static TransactionModel ToModel(this NormalTransactionResponse response)
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