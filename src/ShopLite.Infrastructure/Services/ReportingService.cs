using Microsoft.EntityFrameworkCore;
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
        var orders = _orders.Query();
        var customers = _customers.Query()
            .Where(c => orders.Where(o => o.CustomerId == c.Id)
            .Select(o => o.Amount).Sum() >= minimumTotal);
        var results = customers.Select(c => new TopCustomerDto(c.Name, orders.Where(o => o.CustomerId == c.Id)
            .Select(o => o.Amount).Sum()))
            .OrderByDescending(r => r.TotalAmount).ToList();

        return results;
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

        var products = from p in _db.Products
                join o in _db.Orders
            on p.Id equals o.ProductId into grouped
                select new
                {
                    product= p,
                    orders = grouped.ToList()
                };
        var result = products.Select(p =>
            new ProductSalesDto(
                p.product.Name,
                p.orders.Select(o => o.Quantity).Sum(),
                p.orders.Select(o => o.Amount).Sum()))
            .OrderBy(p => p.TotalAmount)
            .ToList();

        return result;

    }
}
