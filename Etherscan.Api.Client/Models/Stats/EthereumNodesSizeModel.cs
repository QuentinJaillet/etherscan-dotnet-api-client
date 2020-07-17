using Etherscan.Api.Client.Enums;

namespace Etherscan.Api.Client.Models.Stats
{
    public class EthereumNodesSizeModel
    {
        public string BlockNumber { get; set; }

        public string ChainTimeStamp { get; set; }

        public string ChainSize { get; set; }

        public ClientType ClientType { get; set; }

        public SyncMode SyncMode { get; set; }
    }
}