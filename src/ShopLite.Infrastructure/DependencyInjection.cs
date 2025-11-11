using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopLite.Application.Interfaces;
using ShopLite.Application.Services;
using ShopLite.Infrastructure.Repositories;
using ShopLite.Infrastructure.Services;

namespace ShopLite.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Use a simple in-memory database for demo
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("shoplite"));

        services.AddScoped<IProductRepository, EfProductRepository>();
        services.AddScoped<ICustomerRepository, EfCustomerRepository>();
        services.AddScoped<IOrderRepository, EfOrderRepository>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductAppService, ProductAppService>();
        services.AddScoped<IReportingService, ReportingService>();

        // Seeder depends on AppDbContext, so it must be Scoped
        services.AddScoped<IDataSeeder, DataSeeder>();

        return services;
    }
}
