namespace Etherscan.Api.Client.Responses.Stats
{
    internal class EthereumNodesSizeRespnse
    {
        public string blockNumber { get; set; }

        public string chainTimeStamp { get; set; }

        public string chainSize { get; set; }

        public string clientType { get; set; }
        
        public string syncMode { get; set; }
    }
}