using Carpool.BLL.Services.Campus;
using Carpool.BLL.Services.Ride;
using Carpool.BLL.Services.Schedule;
using Microsoft.Extensions.DependencyInjection;

namespace Carpool.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<IRideService, RideService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<ICampusService, CampusService>();

            return services;
        }
    }
}
