using Mapster;
using MapsterMapper;
using System.Reflection;

namespace Carpool.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentationDependency(this IServiceCollection services)
        {
            AddMapping(services);
            return services;
        }

        private static void AddMapping(IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);

            services.AddScoped<IMapper, ServiceMapper>();
        }
    }
}
