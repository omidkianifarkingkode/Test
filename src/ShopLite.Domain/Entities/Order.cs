namespace ShopLite.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid CustomerId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    private Order() { }

    public Order(Guid customerId, Guid productId, int quantity, decimal amount)
    {
        // TODO: quantity > 0, amount >= 0
        CustomerId = customerId;
        ProductId = productId;
        if (quantity > 0)
            Quantity = quantity;
        if (amount >= 0)
            Amount = amount;
    }
}
