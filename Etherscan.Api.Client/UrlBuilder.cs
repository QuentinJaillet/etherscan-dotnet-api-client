using System;

namespace Etherscan.Api.Client
{
    public enum Module
    {
        Transaction,
        Block
    }

    internal class UrlBuilder
    {
        private string _url;

        public UrlBuilder()
        {
            _url = string.Empty;
        }

        public UrlBuilder WithModule(Module module)
        {
            if (module == Module.Transaction)
                _url += "?module=transaction";

            if (module == Module.Block)
                _url += "?module=block";

            return this;
        }

        public UrlBuilder WithBlockNo(string blockNo)
        {
            _url += string.Format("&blockno={0}", blockNo);
            return this;
        }

        public UrlBuilder WithAction(string action)
        {
            _url += string.Format("&action={0}", action);
            return this;
        }

        public UrlBuilder WithApiKey(string apiKey)
        {
            _url += string.Format("&apikey={1}", apiKey);
            return this;
        }

        public UrlBuilder WithTransactionHash(string txhash)
        {
            _url += string.Format("&txhash={0}", txhash);
            return this;
        }

        public string Build()
        {
            return _url;
        }
    }
}
