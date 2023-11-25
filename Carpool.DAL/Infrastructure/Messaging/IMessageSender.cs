using SharedContracts;
using SharedContracts.Events;

namespace Carpool.DAL.Infrastructure.Messaging
{
    public interface IMessageSender
    {
        Task SendInvitedRideEvent(InvitedRideEvent messageEvent);
        Task SendSaveTripEvent(SaveTripEvent messageEvent);
        Task SendDeclinedRideEvent(DeclinedRideEvent messageEvent);
        Task SendCompleteRideEvent(CompleteTripEvent messageEvent);
    }
}
