using ShopLite.Domain.Entities;

namespace ShopLite.Application.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken ct);
    Task AddAsync(Product product, CancellationToken ct);
    Task UpdateAsync(Product product, CancellationToken ct);
    IQueryable<Product> Query();
}

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(Guid id, CancellationToken ct);
    Task AddAsync(Customer customer, CancellationToken ct);
    IQueryable<Customer> Query();
}

public interface IOrderRepository
{
    Task AddAsync(Order order, CancellationToken ct);
    IQueryable<Order> Query();
}
