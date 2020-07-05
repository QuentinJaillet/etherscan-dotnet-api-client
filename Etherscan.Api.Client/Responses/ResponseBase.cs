namespace Etherscan.Api.Client.Responses
{
    internal class ResponseBase<T>
    {
        public string status { get; set; }

        public string message { get; set; }

        public T result { get; set; }
    }
}