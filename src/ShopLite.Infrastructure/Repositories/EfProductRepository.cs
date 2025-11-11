using ShopLite.Application.Interfaces;
using ShopLite.Domain.Entities;

namespace ShopLite.Infrastructure.Repositories;

public class EfProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public EfProductRepository(AppDbContext db)
    {
        _db = db;
    }

    public Task<Product?> GetByIdAsync(Guid id, CancellationToken ct) =>
        _db.Products.FindAsync([id], ct).AsTask();

    public async Task AddAsync(Product product, CancellationToken ct)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Product product, CancellationToken ct)
    {
        _db.Products.Update(product);
        await _db.SaveChangesAsync(ct);
    }

    public IQueryable<Product> Query() => _db.Products.AsQueryable();
}
