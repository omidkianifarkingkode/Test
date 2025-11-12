using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace ShopLite.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }


    public Product(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }

    public void Validate()
    {
        if (Name == string.Empty)
        {
            throw new ArgumentException("invalid name.");
        }
        if (Price < 0)
        {
            throw new ArgumentException("invalid price.");
        }
         if (Stock < 0)
        {
          throw new ArgumentException("invalid stock.");   
        }
        
    }
    public void DecreaseStock(int qty)
    {
    
        if ((qty - 1) >= 0)
        {
            qty--;
            return;
        }
        throw new ArgumentOutOfRangeException();
    }
}
