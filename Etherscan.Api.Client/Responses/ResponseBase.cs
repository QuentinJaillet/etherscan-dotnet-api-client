namespace Etherscan.Api.Client.Responses
{
    public class ResponseBase
    {
        public string status { get; set; }
        public string message { get; set; }
    }

    public class ResponseBase2<T>
    {
        public string status { get; set; }

        public string message { get; set; }

        public T result { get; set; }
    }
}