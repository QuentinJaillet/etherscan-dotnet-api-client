namespace Etherscan.Api.Client
{
    public interface ITokenClient
    {
        long GetERC20TokenTotalSupplyByContractAddress(string contractaddress);

        long GetERC20TokenAccountBalanceForTokenContractAddress(string contractaddress, string address);
    }
}
