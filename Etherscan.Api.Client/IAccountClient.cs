using System.Collections.Generic;
using Etherscan.Api.Client.Models;

namespace Etherscan.Api.Client
{
    public interface IAccountClient
    {
        EtherAddressBalanceModel GetEtherBalanceOfAddress(string address);

        List<EtherAddressBalanceModel> GetEtherBalanceForAddresses(List<string> addresses);
    }
}
