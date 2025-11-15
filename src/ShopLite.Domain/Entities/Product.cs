namespace ShopLite.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public Product(string name, decimal price, int stock)
    {
        // TODO: validate name not empty, price >= 0, stock >= 0
        Name = name;
        Price = price;
        Stock = stock;
    }

    public void DecreaseStock(int qty)
    {
        // TODO:
        // - Validate qty > 0
        // - If qty is greater than available Stock, throw an exception
        // - Otherwise subtract qty from Stock

        throw new NotImplementedException();
    }
}
