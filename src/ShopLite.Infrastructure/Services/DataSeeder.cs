using Microsoft.EntityFrameworkCore;
using ShopLite.Application.Services;
using ShopLite.Domain.Entities;

namespace ShopLite.Infrastructure.Services;

public class DataSeeder : IDataSeeder
{
    private readonly AppDbContext _db;

    public DataSeeder(AppDbContext db)
    {
        _db = db;
    }

    public async Task SeedAsync(CancellationToken ct)
    {
        if (await _db.Products.AnyAsync(ct))
            return;

        _db.Products.AddRange(
            new Product("Phone", 500, 5),
            new Product("Laptop", 1500, 3),
            new Product("Mouse", 20, 50));

        _db.Customers.AddRange(
            new Customer("Ali", "ali@example.com"),
            new Customer("Sara", "sara@example.com"));

        await _db.SaveChangesAsync(ct);
    }
}
