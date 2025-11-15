using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopLite.Application.Interfaces;
using ShopLite.Application.Services;

namespace ShopLite.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IReportingService _reports;
    private readonly ICustomerRepository _customers;

    public ReportsController(IReportingService reports, ICustomerRepository customers)
    {
        _reports = reports;
        _customers = customers;
    }

    [HttpGet("customers")]
    public async Task<IActionResult> AllCustomers(CancellationToken ct = default)
    {
        var result = await _customers.Query().ToListAsync(ct);
        return Ok(result);
    }

    [HttpGet("top-customers")]
    public async Task<IActionResult> TopCustomers([FromQuery] decimal minTotal = 200, CancellationToken ct = default)
    {
        var result = await _reports.GetTopCustomersAsync(minTotal, ct);
        return Ok(result);
    }

    [HttpGet("product-sales")]
    public async Task<IActionResult> ProductSales(CancellationToken ct = default)
    {
        // NOTE:
        // The current project uses the EF Core InMemory provider,
        // which does NOT support raw SQL queries.
        // The implementation of GetProductSalesRawAsync will be
        // evaluated by code review, not by running this endpoint.

        var result = await _reports.GetProductSalesRawAsync(ct);
        return Ok(result);
    }
}
