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
        // TODO :
        // 1) Ensure Customer and Product exist; throw InvalidOperationException if not.
        // 2) Call product.DecreaseStock(quantity).
        // 3) Calculate amount = product.Price * quantity.
        // 4) Create Order and save via _orders.AddAsync.
        // 5) Update Product via _products.UpdateAsync.

        // After saving the order, optionally enqueue a notification:
        // var queue = _serviceProvider.GetService<IQueue<Guid>>();
        // queue?.Enqueue(order.Id);

        throw new NotImplementedException();
    }
}
