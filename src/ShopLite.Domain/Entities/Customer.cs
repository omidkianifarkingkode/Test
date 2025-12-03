using System.ComponentModel.DataAnnotations;

namespace ShopLite.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    public Customer(string name, [EmailAddress] string email)
    {
        // TODO: validate name not empty, email contains '@'
        if (!string.IsNullOrEmpty(name))
            Name = name;
        else
            throw new Exception("name cant be null");
        Email = email;
    }
}
