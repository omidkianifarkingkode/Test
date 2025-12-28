using System.ComponentModel.DataAnnotations;

namespace ShopLite.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    [Required, MinLength(3), MaxLength(64)]
    public string Name { get; private set; } = string.Empty;

    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public Product(string name, decimal price, int stock)
    {
        // TODO: validate name not empty, price >= 0, stock >= 0
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));
        if (stock < 0)
                throw new ArgumentOutOfRangeException(nameof(stock),
                    "Stock must be greater than or equal to 0.");
        if (price < 0)
            throw new ArgumentOutOfRangeException(nameof(price),
                "Price must be greater than or equal to 0.");
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
        if (qty <= 0)
            throw new ArgumentOutOfRangeException(nameof(qty), "Quantity must be greater than zero.");

        if (qty > Stock)
            throw new ArgumentException("Insufficient stock.", nameof(qty));

        Stock -= qty;

    }
}