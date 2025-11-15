namespace ShopLite.Application.DTOs;

public record ProductDto(Guid Id, string Name, decimal Price, int Stock);
public record CreateProductDto(string Name, decimal Price, int Stock);
public record UpdateProductDto(string? Name, decimal? Price, int? Stock);
public record ProductSalesDto(string ProductName, int TotalQuantity, decimal TotalAmount);
