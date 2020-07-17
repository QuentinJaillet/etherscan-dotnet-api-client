using System;
using Etherscan.Api.Client.Enums;

namespace Etherscan.Api.Client
{
    internal enum Module
    {
        Transaction,
        Block,
        Account,
        Stats,
        GasTracker
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
            if (module == Module.Account)
                _url += "?module=account";

            if (module == Module.Transaction)
                _url += "?module=transaction";

            if (module == Module.Block)
                _url += "?module=block";

            if (module == Module.Stats)
                _url += "?module=stats";

            if (module == Module.GasTracker)
                _url += "?module=gastracker";

            return this;
        }

        public UrlBuilder WithGasPrice(long gasprice)
        {
            _url += string.Format("&gasprice={0}", gasprice);
            return this;
        }

        public UrlBuilder WithContractAddress(string contractaddress)
        {
            _url += string.Format("&contractaddress={0}", contractaddress);
            return this;
        }

        public UrlBuilder WithBlockNo(string blockNo)
        {
            _url += string.Format("&blockno={0}", blockNo);
            return this;
        }

        public UrlBuilder WithAddress(string address)
        {
            _url += string.Format("&address={0}", address);
            return this;
        }

        public UrlBuilder WithSyncMode(SyncMode syncMode)
        {
            _url += string.Format("&syncmode={0}", syncMode == SyncMode.Archive ? "archive" : "default");
            return this;
        }

        public UrlBuilder WithSort(Sort sort)
        {
            _url += string.Format("&sort={0}", sort == Sort.Asc ? "asc" : "desc");
            return this;
        }

        public UrlBuilder WithClientType(ClientType clientType)
        {
            _url += string.Format("&clienttype={0}", clientType == ClientType.Geth ? "geth" : "parity");
            return this;
        }

        public UrlBuilder WithEndDate(DateTime enddate)
        {
            _url += string.Format("&enddate={0}", enddate.ToString("yyyy-MM-dd"));
            return this;
        }

        public UrlBuilder WithStartDate(DateTime startdate)
        {
            _url += string.Format("&startdate={0}", startdate.ToString("yyyy-MM-dd"));
            return this;
        }

        public UrlBuilder WithTag(string tag)
        {
            _url += string.Format("&tag={0}", tag);
            return this;
        }

        public UrlBuilder WithAction(string action)
        {
            _url += string.Format("&action={0}", action);
            return this;
        }

        public UrlBuilder WithApiKey(string apiKey)
        {
            _url += string.Format("&apikey={0}", apiKey);
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
