using MassTransit;

namespace Carpool.Api.Extensions
{
    public static class MassTransitExtension
    {
        public static void AddMassTransitDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();
                x.UsingRabbitMq((context, busFactoryConfigurator) =>
                {
                    busFactoryConfigurator.Host(configuration.GetConnectionString("RabbitMq"));
                });
            });
        }
    }
}
