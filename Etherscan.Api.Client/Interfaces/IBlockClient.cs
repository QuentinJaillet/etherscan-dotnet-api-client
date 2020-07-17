using Etherscan.Api.Client.Models.Transaction;

namespace Etherscan.Api.Client.Interfaces
{
    public interface IBlockClient
    {
        BlockAndUncleRewardsModel GetBlockAndUncleRewardsbyBlockNo(string blockNo);

        EstimatedBlockCountdownTimeModel GetEstimatedBlockCountdownTimebyBlockNo(string blockNo);

        void GetBlockNumberbyTimestamp();
    }
}
