namespace ShopLite.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    public Customer(string name, string email)
    {
        Name = name;
        Email = email;
    }
    public void Validate()
    {
        if (Email == string.Empty || !Email.Contains('@'))
            throw new ArgumentException("Invalid email format.");

        if (Name == string.Empty)
            throw new ArgumentException("Invalid name.");
    }
}
