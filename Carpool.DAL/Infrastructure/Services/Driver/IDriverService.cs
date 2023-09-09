namespace Carpool.DAL.Infrastructure.Services.Driver
{
    public interface IDriverService
    {
        Task<Model.Driver> GetDriverBasicInfos(int driverId);
    }
}
