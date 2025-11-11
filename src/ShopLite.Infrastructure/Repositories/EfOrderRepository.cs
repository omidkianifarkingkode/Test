using Microsoft.EntityFrameworkCore;
using ShopLite.Application.Interfaces;
using ShopLite.Domain.Entities;

namespace ShopLite.Infrastructure.Repositories;

public class EfOrderRepository : IOrderRepository
{
    private readonly AppDbContext _db;

    public EfOrderRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Order order, CancellationToken ct)
    {
        _db.Orders.Add(order);
        await _db.SaveChangesAsync(ct);
    }

    public IQueryable<Order> Query() => _db.Orders.AsNoTracking();
}
