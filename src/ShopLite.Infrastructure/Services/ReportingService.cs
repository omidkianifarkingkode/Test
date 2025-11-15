using Microsoft.EntityFrameworkCore;
using System.Linq;

using ShopLite.Application.DTOs;
using ShopLite.Application.Interfaces;
using ShopLite.Application.Services;

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
        var customers = await _db.Customers
            .GroupJoin(
                _db.Orders,
                customer => customer.Id,
                order => order.CustomerId,
                (customer, orders) => new
                {
                    customer.Name,
                    TotalAmount = orders.Sum(o => (decimal?)o.Amount) ?? 0m
                })
            .Where(x => x.TotalAmount >= minimumTotal)
            .OrderByDescending(x => x.TotalAmount)
            .ThenBy(x => x.Name)
            .Select(x => new TopCustomerDto(x.Name, x.TotalAmount))
            .ToListAsync(ct);

        return customers;
    }

    //  Note: the current project uses the EF Core InMemory provider,
    //  which does not support raw SQL at runtime.
    //  This task will be verified by** code review only**, not by executing the query.
    public async Task<IReadOnlyCollection<ProductSalesDto>> GetProductSalesRawAsync(CancellationToken ct)
    {
        const string sql = """
            SELECT p.Name AS ProductName,
                   SUM(o.Quantity) AS TotalQuantity,
                   SUM(o.Amount) AS TotalAmount
            FROM Products AS p
            INNER JOIN Orders AS o ON o.ProductId = p.Id
            GROUP BY p.Name
            ORDER BY TotalAmount DESC
            """;

        throw new PlatformNotSupportedException();
    }

    private sealed class ProductSalesRow
    {
        public string ProductName { get; set; } = string.Empty;
        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
