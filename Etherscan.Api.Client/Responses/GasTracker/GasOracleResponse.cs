namespace Etherscan.Api.Client.Responses.GasTracker
{
    internal class GasOracleResponse
    {
        public string LastBlock { get; set; }
        
        public string SafeGasPrice { get; set; }

        public string ProposeGasPrice { get; set; }
    }
}