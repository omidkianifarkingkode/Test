using System.ComponentModel.DataAnnotations;

namespace ShopLite.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    [Required]
    [MinLength(3),MaxLength(64)]
    public string Name { get; private set; } = string.Empty;
    [EmailAddress]
    public string Email { get; private set; } = string.Empty;

    public Customer(string name, string email)
    {
        // TODO: validate name not empty, email contains '@'
        if(email.Contains("@"))
            throw new ArgumentException("Invalid email address");
        Name = name;
        Email = email;
    }
}
