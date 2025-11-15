using Microsoft.Extensions.DependencyInjection;

using ShopLite.Application.Interfaces;
using ShopLite.Application.Services;
using ShopLite.Domain.Entities;

namespace ShopLite.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IProductRepository _products;
    private readonly ICustomerRepository _customers;
    private readonly IOrderRepository _orders;
    private readonly IServiceProvider _serviceProvider; // used for optional IQueue<Guid>

    public OrderService(IProductRepository products, ICustomerRepository customers, IOrderRepository orders, IServiceProvider serviceProvider)
    {
        _products = products;
        _customers = customers;
        _orders = orders;
        _serviceProvider = serviceProvider;
    }

    public async Task<Guid> PlaceOrderAsync(Guid customerId, Guid productId, int quantity, CancellationToken ct)
    {
        var customer = await _customers.GetByIdAsync(customerId, ct);
        if (customer is null)
        {
            throw new InvalidOperationException($"Customer '{customerId}' was not found.");
        }

        var product = await _products.GetByIdAsync(productId, ct);
        if (product is null)
        {
            throw new InvalidOperationException($"Product '{productId}' was not found.");
        }

        product.DecreaseStock(quantity);

        var amount = product.Price * quantity;
        var order = new Order(customerId, productId, quantity, amount);

        await _orders.AddAsync(order, ct);
        await _products.UpdateAsync(product, ct);

        var queue = _serviceProvider.GetService<IQueue<Guid>>();
        queue?.Enqueue(order.Id);

        return order.Id;
    }
}
