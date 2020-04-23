namespace Etherscan.Api.Client
{
    public interface IAccountClient
    {
        int GetEtherBalanceOfAddress(string address);
    }
}
