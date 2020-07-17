using Etherscan.Api.Client.Models.GasTracker;

namespace Etherscan.Api.Client
{
    public interface IGasTrackerClient
    {
        int GetEstimationOfConfirmationTime(long gasprice);

        GasOracleModel GetGasOracle();
    }
}
