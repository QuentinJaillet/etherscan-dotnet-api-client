namespace Etherscan.Api.Client.Models.GasTracker
{
    public class GasOracleModel
    {
        public string LastBlock { get; set; }

        public string SafeGasPrice { get; set; }

        public string ProposeGasPrice { get; set; }
    }
}