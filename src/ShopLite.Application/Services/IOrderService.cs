namespace ShopLite.Application.Services;

public interface IOrderService
{
    Task<Guid> PlaceOrderAsync(Guid customerId, Guid productId, int quantity, CancellationToken ct);
}
