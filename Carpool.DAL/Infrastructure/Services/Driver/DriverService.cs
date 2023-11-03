using Carpool.DAL.Infrastructure.Services.Common;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Carpool.DAL.Infrastructure.Services.Driver
{
    public class DriverService : IDriverService
    {
        private readonly IApiCaller _apiCaller;
        private readonly ILogger<DriverService> _logger;
        public DriverService(IApiCaller apiCaller, ILogger<DriverService> logger)
        {
            _apiCaller = apiCaller;
            _logger = logger;
        }

        public async Task<Model.Driver> GetDriverBasicInfos(int driverId)
        {
            try
            {
                return await _apiCaller.GetUserInformation<Model.Driver>(HttpMethod.Get,
                    $"driver/{driverId}/basic-infos");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "[Univan] Fail to retrieve driver information");
                return null;
            }
        }
    }
}
