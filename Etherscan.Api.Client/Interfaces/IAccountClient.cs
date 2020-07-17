using System.Collections.Generic;
using Etherscan.Api.Client.Enums;
using Etherscan.Api.Client.Models;

namespace Etherscan.Api.Client.Interfaces
{
    public interface IAccountClient
    {
        EtherAddressBalanceModel GetEtherBalanceOfAddress(string address);

        List<EtherAddressBalanceModel> GetEtherBalanceForAddresses(List<string> addresses);

        List<TransactionModel> GetNormalTransactionsOfAddress(string address, Sort sort = Sort.Asc, int startblock = 0, int endblock = 99999999);
    }
}
