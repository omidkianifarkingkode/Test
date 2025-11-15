using ShopLite.Application.DTOs;
using ShopLite.Application.Interfaces;
using ShopLite.Application.Services;
using ShopLite.Domain.Entities;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ShopLite.Infrastructure.Services;

public class ReportingService : IReportingService
{
    private readonly ICustomerRepository _customers;
    private readonly IOrderRepository _orders;
    private readonly AppDbContext _db;

    public ReportingService(ICustomerRepository customers, IOrderRepository orders, AppDbContext db)
    {
        _customers = customers;
        _orders = orders;
        _db = db;
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

    //  Note: the current project uses the EF Core InMemory provider,
    //  which does not support raw SQL at runtime.
    //  This task will be verified by** code review only**, not by executing the query.
    public async Task<IReadOnlyCollection<ProductSalesDto>> GetProductSalesRawAsync(CancellationToken ct)
    {
        // TODO: implement this method using RAW SQL.
        // Requirements:
        // - Join Products and Orders.
        // - Group by product.
        // - Select ProductName, TotalQuantity (SUM of Quantity), TotalAmount (SUM of Amount).
        // - Order by TotalAmount DESC.

        throw new NotImplementedException();
    }
}
