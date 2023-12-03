using Carpool.DAL.Infrastructure.Services.Student;
using Carpool.DAL.Infrastructure.Services.Student.Model;
using Microsoft.Extensions.Caching.Memory;

namespace Carpool.DAL.Infrastructure.Services.Driver
{
    public class CachedDriverService : IDriverService
    {
        private readonly IDriverService _decorated;
        private readonly IMemoryCache _memoryCache;
        public CachedDriverService(IDriverService driverService, IMemoryCache memoryCache)
        {
            _decorated = driverService;
            _memoryCache = memoryCache;
        }

        public Task<Model.Driver> GetDriverBasicInfos(int driverId)
        {
            string key = $"driver-{driverId}";

            return _memoryCache.GetOrCreateAsync(
                key,
                entry =>
                {
                    entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                    return _decorated.GetDriverBasicInfos(driverId);
                });
        }

    }
}
