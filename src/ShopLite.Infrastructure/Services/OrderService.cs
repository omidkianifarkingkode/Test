using System.Data.Common;
using ShopLite.Application.Interfaces;
using ShopLite.Application.Services;
using ShopLite.Domain.Entities;

namespace ShopLite.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IProductRepository _products;
    private readonly ICustomerRepository _customers;
    private readonly IOrderRepository _orders;

    public OrderService(IProductRepository products, ICustomerRepository customers, IOrderRepository orders)
    {
        _products = products;
        _customers = customers;
        _orders = orders;
    }

    public async Task<Guid> PlaceOrderAsync(Guid customerId, Guid productId, int quantity, CancellationToken ct)
    {
        var customer = await _customers.GetByIdAsync(customerId, ct);
        
        if (customer == null)
            throw new InvalidOperationException();

         var product = await _products.GetByIdAsync(productId,ct);

        if (product == null)
            throw new InvalidOperationException();

        product.Validate();

        var order = new Order(customerId, productId, quantity,product.Price*quantity);
        await _orders.AddAsync(order, ct);
        await _products.UpdateAsync(product, ct);

        return order.Id;
    }
}
