using Etherscan.Api.Client.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Etherscan.Api.Client
{
    public static class EtherscanApiClientExtensions
    {
        public static IServiceCollection AddEtherscanApiClient(this IServiceCollection services)
        {
            services.AddTransient<IAccountClient, AccountClient>();
            services.AddTransient<IBlockClient, BlockClient>();
            //services.AddTransient<IContractClient, ContractClient>();
            services.AddTransient<IGasTrackerClient, GasTrackerClient>();
            services.AddTransient<IStatsClient, StatsClient>();
            services.AddTransient<ITokenClient, TokenClient>();
            services.AddTransient<ITransactionClient, TransactionClient>();
            return services;
        }

        public static IServiceCollection AddEtherscanApiClient(this IServiceCollection services, string apiKey)
        {
            if (!string.IsNullOrEmpty(apiKey))
                services.AddSingleton<IApiKeyClient>(new ApiKeyClient(apiKey));

            return AddEtherscanApiClient(services);
        }
    }
}
