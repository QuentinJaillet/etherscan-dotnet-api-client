using Etherscan.Api.Client.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Etherscan.Api.Client
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddEtherscanApiClient(this IServiceCollection services)
        {
            services.AddTransient<IAccountClient, AccountClient>();
            return services;
        }
    }
}
