using Etherscan.Api.Client.Models.Transaction;

namespace Etherscan.Api.Client
{
    public interface IBlockClient
    {
        BlockAndUncleRewardsModel GetBlockAndUncleRewardsbyBlockNo(string blockNo);

        void GetEstimatedBlockCountdownTimebyBlockNo(string blockNo);

        void GetBlockNumberbyTimestamp();
    }
}
