using Etherscan.Api.Client.Models.GasTracker;
using Etherscan.Api.Client.Responses.GasTracker;

namespace Etherscan.Api.Client.Mappers
{
    internal static class GasTrackerMapper
    {
        public static GasOracleModel ToModel(this GasOracleResponse response)
        {
            var model = new GasOracleModel();
            model.LastBlock = response.LastBlock;
            model.ProposeGasPrice = response.ProposeGasPrice;
            model.SafeGasPrice = response.SafeGasPrice;
            return model;
        }
    }
}