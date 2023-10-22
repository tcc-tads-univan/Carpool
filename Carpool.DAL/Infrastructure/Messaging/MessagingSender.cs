using Carpool.DAL.Domain;
using Carpool.DAL.Domain.Event;
using MassTransit;
using Microsoft.Extensions.Logging;

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

        public async Task SendEvent(BaseEvent messageEvent)
        {
            await _publish.Publish(messageEvent);
            _logger.LogInformation("Message sent: " + messageEvent.GetType());
        }
    }
}
