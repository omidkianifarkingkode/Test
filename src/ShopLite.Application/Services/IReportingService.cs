using ShopLite.Application.DTOs;

namespace ShopLite.Application.Services;

public record TopCustomerDto(string Name, decimal TotalAmount);

public interface IReportingService
{
    Task<IReadOnlyCollection<TopCustomerDto>> GetTopCustomersAsync(decimal minimumTotal, CancellationToken ct);

    Task<IReadOnlyCollection<ProductSalesDto>> GetProductSalesRawAsync(CancellationToken ct);
}
