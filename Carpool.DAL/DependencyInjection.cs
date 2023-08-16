﻿using Carpool.DAL.Persistence.Redis;
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

            services.AddSingleton<IConnectionMultiplexer>(opt => ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")));

            services.AddDbContext<CarpoolContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("CarpoolDatabase")));

            return services;
        }
    }
}
