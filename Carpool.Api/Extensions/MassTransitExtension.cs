using MassTransit;
using RabbitMQ.Client;
using SharedContracts.Events;

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

                    busFactoryConfigurator.Message<BaseCarpoolEvent>(e => e.SetEntityName(BaseCarpoolEvent.exchageName));
                    busFactoryConfigurator.Publish<BaseCarpoolEvent>(e => {
                        e.ExchangeType = ExchangeType.Direct;
                    });
                });
            });
        }
    }
}
