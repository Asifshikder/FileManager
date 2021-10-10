using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Services.Media;
using System;

namespace Project.Services
{
    public static class IocContainer
    {
        public static IServiceCollection AddServicelayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPageService, PageService>();
            return services;
        }
    }
}
