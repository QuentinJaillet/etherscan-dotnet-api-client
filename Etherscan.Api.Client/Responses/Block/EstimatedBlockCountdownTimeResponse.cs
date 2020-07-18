namespace Etherscan.Api.Client.Responses.Block
{
    internal class EstimatedBlockCountdownTimeResponse
    {
        public string CurrentBlock { get; set; }
        
        public string CountdownBlock { get; set; }

        public string RemainingBlock { get; set; }

        public string EstimateTimeInSec { get; set; }
    }
}