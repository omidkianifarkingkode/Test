using Microsoft.AspNetCore.Mvc;
using ShopLite.Application.Services;

namespace ShopLite.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orders;

    public OrdersController(IOrderService orders)
    {
        _orders = orders;
    }

    public record PlaceOrderRequest(Guid CustomerId, Guid ProductId, int Quantity);

    [HttpPost]
    public async Task<IActionResult> Place([FromBody] PlaceOrderRequest body, CancellationToken ct)
    {
        if (body.Quantity <= 0)
        {
            return BadRequest(new { message = "Quantity must be greater than zero." });
        }

        try
        {
            var id = await _orders.PlaceOrderAsync(body.CustomerId, body.ProductId, body.Quantity, ct);
            return CreatedAtAction(nameof(Place), new { id }, new { orderId = id });
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
