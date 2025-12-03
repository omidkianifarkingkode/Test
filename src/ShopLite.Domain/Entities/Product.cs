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
        if (!string.IsNullOrEmpty(name))
            Name = name;
        else
            throw new Exception("name cant to be null");

        if (price >= 0)
            Price = price;
        else throw new Exception("price can not to be minze");
        if (stock >= 0)
            Stock = stock;
        else throw new Exception("stock can not to be minze");
        
    }

    public void DecreaseStock(int qty)
    {
        // TODO:
        // - Validate qty > 0
        // - If qty is greater than available Stock, throw an exception
        // - Otherwise subtract qty from Stock
        if (qty > 0 && qty < Stock)
            Stock -= qty;
        else if (qty > Stock)
            throw new NotImplementedException("qty bigger than stock");
    }
}
