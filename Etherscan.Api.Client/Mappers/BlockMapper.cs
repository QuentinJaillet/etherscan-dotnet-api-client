using System.Collections.Generic;
using Etherscan.Api.Client.Models.Transaction;
using Etherscan.Api.Client.Responses.Block;

namespace Etherscan.Api.Client.Mappers
{
    internal static class BlockMapper
    {
        public static BlockAndUncleRewardsModel ToModel(this BlockAndUncleRewardsResponse response)
        {
            var model = new BlockAndUncleRewardsModel();
            model.BlockMiner = response.blockMiner;
            model.BlockNumber = response.blockNumber;
            model.BlockReward = response.blockReward;
            model.TimeStamp = response.timeStamp;
            model.UncleInclusionReward = response.uncleInclusionReward;
            model.Uncles = response.uncles.ToModels();
            return model;
        }

        public static EstimatedBlockCountdownTimeModel ToModel(this EstimatedBlockCountdownTimeResponse response)
        {
            var model = new EstimatedBlockCountdownTimeModel();
            model.CountdownBlock = response.CountdownBlock;
            model.CurrentBlock = response.CurrentBlock;
            model.EstimateTimeInSec = response.EstimateTimeInSec;
            model.RemainingBlock = response.RemainingBlock;
            return model;
        }

        public static List<UncleModel> ToModels(this List<UncleResponse> uncles)
        {
            var model = new List<UncleModel>();

            foreach (var uncle in uncles)
                model.Add(uncle.ToModel());

            return model;
        }

        public static UncleModel ToModel(this UncleResponse response)
        {
            return new UncleModel
            {
                BlockReward = response.blockreward,
                Miner = response.miner,
                UnclePosition = response.unclePosition
            };
        }
    }
}