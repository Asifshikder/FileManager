using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.Data;
using Project.Infrastructure.Repository;
using System;

namespace Project.Infrastructure
{
    public static class IocContainer
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FileManagementDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("constring"));
                option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Transient);


            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
            services.AddHttpContextAccessor();
            return services;

        }
    }
}
