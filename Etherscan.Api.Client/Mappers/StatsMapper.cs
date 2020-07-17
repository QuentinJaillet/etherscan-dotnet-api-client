using System.Collections.Generic;
using Etherscan.Api.Client.Enums;
using Etherscan.Api.Client.Models.Stats;
using Etherscan.Api.Client.Responses.Stats;

namespace Etherscan.Api.Client.Mappers
{
    internal static class StatsMapper
    {
        public static EtherLastPriceModel ToModel(this EtherLastPriceResponse response)
        {
            var model = new EtherLastPriceModel();
            model.EthBtc = response.ethbtc;
            model.EthBtcTimeStamp = response.ethbtc_timestamp;
            model.EthUsd = response.ethusd;
            model.EthUsdTimeStamp = response.ethusd_timestamp;
            return model;
        }

        public static EthereumNodesSizeModel ToModel(this EthereumNodesSizeRespnse response)
        {
            var model = new EthereumNodesSizeModel();
            model.BlockNumber = response.blockNumber;
            model.ChainSize = response.chainSize;
            model.ChainTimeStamp = response.chainTimeStamp;
            model.ClientType = response.clientType.ToLower() == "geth" ? ClientType.Geth : ClientType.Parity;
            model.SyncMode = response.syncMode.ToLower() == "archive" ? SyncMode.Archive : SyncMode.Default;
            return model;
        }

        public static List<EthereumNodesSizeModel> ToModels(this List<EthereumNodesSizeRespnse> ethereumNodes)
        {
            var model = new List<EthereumNodesSizeModel>();

            foreach (var node in ethereumNodes)
                model.Add(node.ToModel());

            return model;
        }
    }
}