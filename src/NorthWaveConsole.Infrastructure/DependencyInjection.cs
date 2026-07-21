using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NorthWaveConsole.Application.Interfaces;
using NorthWaveConsole.Application.Services;
using NorthWaveConsole.Infrastructure.Persistence;
using NorthWaveConsole.Infrastructure.Services;

namespace NorthWaveConsole.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<NorthWaveDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPricingService, PricingOrder>();
            services.AddScoped<INotificationService, NotifyOrder>();
            services.AddScoped<IOrderLogger, LoggerOrder>();

            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IJwtTokenService, JwtTokenService>();

            services.AddScoped<IOrderService, OrderService>();

            return services;
        }
    }
}
