using ShopLite.Application.DTOs;

namespace ShopLite.Application.Services;

public interface IProductAppService
{
    Task<IReadOnlyCollection<ProductDto>> GetAsync(CancellationToken ct);
    Task<Guid> CreateAsync(CreateProductDto dto, CancellationToken ct);
}
