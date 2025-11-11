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
        // TODO:
        // 1) Query all customers.
        // 2) For each customer, calculate their total order amount by summing all related orders.
        // 3) Filter customers whose total order amount >= minimumTotal.
        // 4) Map the results to TopCustomerDto (Name, TotalAmount).
        // 5) Sort descending by TotalAmount and return as a read-only collection.
        throw new NotImplementedException();
    }
}
