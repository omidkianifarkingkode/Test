using Microsoft.EntityFrameworkCore;
using ShopLite.Application.Services;
using ShopLite.Domain.Entities;

namespace ShopLite.Infrastructure.Services;

public class DataSeeder : IDataSeeder
{
    private readonly IDbContextFactory<AppDbContext> _factory;

    public DataSeeder(IDbContextFactory<AppDbContext> factory)
    {
        _factory = factory;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        await using var db = await _factory.CreateDbContextAsync(ct);

        if (await db.Products.AnyAsync(ct))
        {
            return;
        }

        db.Products.AddRange(
            new Product("Phone", 500, 5),
            new Product("Laptop", 1500, 3),
            new Product("Mouse", 20, 50));

        db.Customers.AddRange(
            new Customer("Ali", "ali@example.com"),
            new Customer("Sara", "sara@example.com"));

        await db.SaveChangesAsync(ct);
    }
}
