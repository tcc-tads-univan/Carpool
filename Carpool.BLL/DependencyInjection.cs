using Microsoft.Extensions.DependencyInjection;

namespace Carpool.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            return services;
        }
    }
}
