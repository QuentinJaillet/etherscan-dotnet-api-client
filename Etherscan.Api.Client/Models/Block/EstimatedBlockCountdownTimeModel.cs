namespace Etherscan.Api.Client.Models.Transaction
{
    public class EstimatedBlockCountdownTimeModel
    {
        public string CurrentBlock { get; set; }


        public string CountdownBlock { get; set; }


        public string RemainingBlock { get; set; }
        

        public string EstimateTimeInSec { get; set; }
    }
}