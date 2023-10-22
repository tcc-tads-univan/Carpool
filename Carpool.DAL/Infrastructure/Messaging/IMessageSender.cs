using Carpool.DAL.Domain;
using Carpool.DAL.Domain.Event;

namespace Carpool.DAL.Infrastructure.Messaging
{
    public interface IMessageSender
    {
        Task SendEvent(BaseEvent messageEvent);
    }
}
