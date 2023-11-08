using Carpool.DAL.Infrastructure.Messaging;
using Carpool.DAL.Infrastructure.Services.Common;
using Carpool.DAL.Infrastructure.Services.Driver;
using Carpool.DAL.Infrastructure.Services.Route;
using Carpool.DAL.Infrastructure.Services.Student;
using Carpool.DAL.Persistence.Redis;
using Carpool.DAL.Persistence.Redis.Interfaces;
using Carpool.DAL.Persistence.Relational.Context;
using Carpool.DAL.Persistence.Relational.Repository;
using Carpool.DAL.Persistence.Relational.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Carpool.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICampusRepository, CampusRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IRideRepository, RideRepository>();

            services.AddScoped<IMessageSender, MessagingSender>();

            services.AddSingleton<IConnectionMultiplexer>(opt => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));

            services.AddDbContext<CarpoolContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("CarpoolDatabase")));

            services.AddHttpClient<IApiCaller, ApiCaller>(opt =>
            {
                opt.BaseAddress = new Uri(configuration.GetSection("UnivanService")["Url"]);
            });

            services.AddHttpClient<IRouteService, RouteService>(opt =>
            {
                opt.BaseAddress = new Uri(configuration.GetSection("RouteService")["Url"]);
            });

            services.AddScoped<IStudentService, StudentService>();
            services.Decorate<IStudentService, CachedStudentService>();
            
            services.AddScoped<IDriverService, DriverService>();
            services.Decorate<IDriverService, CachedDriverService>();

            services.AddMemoryCache();

            return services;
        }
    }
}
