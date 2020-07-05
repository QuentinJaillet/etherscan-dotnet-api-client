namespace Etherscan.Api.Client.Responses
{
    public class ResponseBase<T>
    {
        public string status { get; set; }

        public string message { get; set; }

        public T result { get; set; }
    }
}