using Microsoft.EntityFrameworkCore;
using ShopLite.Application.Interfaces;
using ShopLite.Domain.Entities;

namespace ShopLite.Infrastructure.Repositories;

public class EfCustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _db;

    public EfCustomerRepository(AppDbContext db)
    {
        _db = db;
    }

    public Task<Customer?> GetByIdAsync(Guid id, CancellationToken ct) =>
        _db.Customers.FindAsync([id], ct).AsTask();

    public async Task AddAsync(Customer customer, CancellationToken ct)
    {
        _db.Customers.Add(customer);
        await _db.SaveChangesAsync(ct);
    }

    public IQueryable<Customer> Query() => _db.Customers.AsQueryable();
}
