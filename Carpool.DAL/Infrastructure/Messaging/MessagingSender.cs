using MassTransit;
using Microsoft.Extensions.Logging;
using SharedContracts;
using SharedContracts.Events;

namespace Carpool.DAL.Infrastructure.Messaging
{
    public class MessagingSender : IMessageSender
    {
        private readonly IPublishEndpoint _publish;
        private readonly ILogger<MessagingSender> _logger;
        public MessagingSender(IPublishEndpoint publish, ILogger<MessagingSender> logger)
        {
            _publish = publish;
            _logger = logger;
        }

        public async Task SendCompleteRideEvent(CompleteTripEvent messageEvent)
        {
            await _publish.Publish(messageEvent, e => e.SetRoutingKey(messageEvent.GetType().Name));
            _logger.LogInformation("CompleteTripEvent sent!");
        }

        public async Task SendDeclinedRideEvent(DeclinedRideEvent messageEvent)
        {
            await _publish.Publish(messageEvent, e => e.SetRoutingKey(messageEvent.GetType().Name));
            _logger.LogInformation("DeclinedRideEvent sent!");
        }

        public async Task SendInvitedRideEvent(InvitedRideEvent messageEvent)
        {
            await _publish.Publish(messageEvent, e => e.SetRoutingKey(messageEvent.GetType().Name));
            _logger.LogInformation("InvitedRideEvent sent!");
        }

        public async Task SendSaveTripEvent(SaveTripEvent messageEvent)
        {
            await _publish.Publish(messageEvent, e => e.SetRoutingKey(messageEvent.GetType().Name));
            _logger.LogInformation("InvitedRideEvent sent!");
        }
    }
}
