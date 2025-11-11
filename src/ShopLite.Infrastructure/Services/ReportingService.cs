using Microsoft.EntityFrameworkCore;
using ShopLite.Application.Interfaces;
using ShopLite.Application.Services;

namespace ShopLite.Infrastructure.Services;

public class ReportingService : IReportingService
{
    private readonly ICustomerRepository _customers;
    private readonly IOrderRepository _orders;

    public ReportingService(ICustomerRepository customers, IOrderRepository orders)
    {
        _customers = customers;
        _orders = orders;
    }

    public async Task<IReadOnlyCollection<TopCustomerDto>> GetTopCustomersAsync(decimal minimumTotal, CancellationToken ct)
    {
        var customersQuery = _customers.Query();
        var ordersQuery = _orders.Query();

        var result = await customersQuery
            .Select(customer => new TopCustomerDto(
                customer.Name,
                ordersQuery.Where(o => o.CustomerId == customer.Id).Sum(o => (decimal?)o.Amount) ?? 0m))
            .Where(customer => customer.TotalAmount >= minimumTotal)
            .OrderByDescending(customer => customer.TotalAmount)
            .ToListAsync(ct);

        return result;
    }
}
