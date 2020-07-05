using System.Collections.Generic;

namespace Etherscan.Api.Client.Responses.Block
{
    internal class BlockAndUncleRewardsResponse
    {
        public string blockNumber { get; set; }

        public string timeStamp { get; set; }

        public string blockMiner { get; set; }

        public string blockReward { get; set; }

        public List<UncleResponse> uncles { get; set; }

        public string uncleInclusionReward { get; set; }
    }
}