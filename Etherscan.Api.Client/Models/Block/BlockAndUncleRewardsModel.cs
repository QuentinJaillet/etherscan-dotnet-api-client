using System.Collections.Generic;

namespace Etherscan.Api.Client.Models.Transaction
{
    public class BlockAndUncleRewardsModel
    {
        public string BlockNumber { get; set; }

        public string TimeStamp { get; set; }

        public string BlockMiner { get; set; }

        public string BlockReward { get; set; }

        public List<UncleModel> Uncles { get; set; }

        public string UncleInclusionReward { get; set; }
    }
}