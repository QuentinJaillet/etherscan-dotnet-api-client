using System.Collections.Generic;

namespace Etherscan.Api.Client.Responses.Account
{
    public class NormalTransactionsResponse : ResponseBase
    {
        public List<NormalTransactionResponse> result { get; set; }
    }
}