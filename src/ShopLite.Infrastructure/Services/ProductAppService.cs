using Microsoft.EntityFrameworkCore;
using ShopLite.Application.DTOs;
using ShopLite.Application.Interfaces;
using ShopLite.Application.Services;
using ShopLite.Domain.Entities;

namespace ShopLite.Infrastructure.Services;

public class ProductAppService : IProductAppService
{
    private readonly IProductRepository _products;

    public ProductAppService(IProductRepository products)
    {
        _products = products;
    }

    public async Task<IReadOnlyCollection<ProductDto>> GetAsync(CancellationToken ct)
    {
        return await _products.Query()
            .AsNoTracking()
            .Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock))
            .ToListAsync(ct);
    }

    public async Task<Guid> CreateAsync(CreateProductDto dto, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(dto.Name) || dto.Price < 0 || dto.Stock < 0)
        {
            throw new ArgumentException("Invalid product payload.");
        }

        var product = new Product(dto.Name, dto.Price, dto.Stock);
        await _products.AddAsync(product, ct);
        return product.Id;
    }
}
