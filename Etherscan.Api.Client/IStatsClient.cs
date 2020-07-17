using System;
using System.Collections.Generic;
using Etherscan.Api.Client.Enums;
using Etherscan.Api.Client.Models.Stats;

namespace Etherscan.Api.Client
{
    public interface IStatsClient
    {
        long GetTotalSupplyOfEther();

        EtherLastPriceModel GetEtherLastPrice();

        List<EthereumNodesSizeModel> GetEthereumNodesSize(DateTime startdate, DateTime enddate, ClientType clientType, SyncMode syncMode, Sort sort);
    }
}
