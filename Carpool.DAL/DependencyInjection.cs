using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Carpool.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IConnectionMultiplexer>(opt => ConnectionMultiplexer.Connect())

            return services;
        }
    }
}
