using Microsoft.AspNetCore.Mvc;
using ShopLite.Application.Services;

namespace ShopLite.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly IReportingService _reports;

    public ReportsController(IReportingService reports)
    {
        _reports = reports;
    }

    [HttpGet("top-customers")]
    public async Task<IActionResult> TopCustomers([FromQuery] decimal minTotal = 200, CancellationToken ct = default)
    {
        var result = await _reports.GetTopCustomersAsync(minTotal, ct);
        return Ok(result);
    }
}
