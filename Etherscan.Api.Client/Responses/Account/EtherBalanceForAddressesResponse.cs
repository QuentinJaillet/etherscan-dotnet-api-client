using System.Collections.Generic;

namespace Etherscan.Api.Client.Responses.Account
{
    public class EtherBalanceForAddressesResponse : ResponseBase
    {
        public List<EtherBalanceForAddressResponse> result { get; set; }
    }   
}