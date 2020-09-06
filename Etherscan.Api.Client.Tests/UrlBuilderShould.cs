using Xunit;

namespace Etherscan.Api.Client.Tests
{
    public class UrlBuilderShould
    {
        [Fact]
        public void Test1()
        {
            var url = new UrlBuilder()
                .WithModule(Module.Account)
                .Build();

            
            Assert.Equal("?module=account", url);
        }

        [Fact]
        public void Test2()
        {
            var url = new UrlBuilder()
                .WithModule(Module.Account)
                .WithAction("myAction")
                .Build();


            Assert.Equal("?module=account&action=myAction", url);
        }

        [Fact]
        public void Test3()
        {
            var url = new UrlBuilder()
                .WithModule(Module.Account)
                .WithAction("myAction")
                .WithAddress("myAddress")
                .Build();

            Assert.Equal("?module=account&action=myAction&address=myAddress", url);
        }
    }
}
