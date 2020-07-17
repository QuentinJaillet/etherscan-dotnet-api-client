using Etherscan.Api.Client.Models.GasTracker;

namespace Etherscan.Api.Client.Interfaces
{
    public interface IGasTrackerClient
    {
        int GetEstimationOfConfirmationTime(long gasprice);

        GasOracleModel GetGasOracle();
    }
}
