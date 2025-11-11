using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using ShopLite.Application.Interfaces;
using ShopLite.Application.Services;
using ShopLite.Infrastructure.Repositories;
using ShopLite.Infrastructure.Services;

namespace ShopLite.Infrastructure;

public static class DependencyInjection
{
    private static readonly InMemoryDatabaseRoot DatabaseRoot = new();

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("shoplite", DatabaseRoot));
        services.AddDbContextFactory<AppDbContext>(options => options.UseInMemoryDatabase("shoplite", DatabaseRoot));
        services.AddScoped<IProductRepository, EfProductRepository>();
        services.AddScoped<ICustomerRepository, EfCustomerRepository>();
        services.AddScoped<IOrderRepository, EfOrderRepository>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductAppService, ProductAppService>();
        services.AddScoped<IReportingService, ReportingService>();
        services.AddSingleton<IDataSeeder, DataSeeder>();
        return services;
    }
}
