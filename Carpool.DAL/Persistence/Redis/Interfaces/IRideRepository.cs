namespace Carpool.DAL.Persistence.Redis.Interfaces
{
    public interface IRideRepository
    {
        Task CreateRideRequest();

        Task DeleteRideRequest();
    }
}
