namespace ShopLite.Application.Services;

public interface IDataSeeder
{
    Task SeedAsync(CancellationToken ct);
}
