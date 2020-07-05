using Etherscan.Api.Client.Models.Transaction;

namespace Etherscan.Api.Client
{
    public interface ITransactionClient
    {
        ContractExecutionStatusModel CheckContractExecutionStatus(string txhash);

        TransactionReceiptStatusModel CheckTransactionReceiptStatus(string txhash);
    }
}
