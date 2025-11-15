using Microsoft.AspNetCore.Mvc;
using ShopLite.Application.DTOs;
using ShopLite.Application.Services;

namespace ShopLite.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductAppService _products;

    public ProductsController(IProductAppService products)
    {
        _products = products;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get(CancellationToken ct)
    {
        var products = await _products.GetAsync(ct);
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductDto dto, CancellationToken ct)
    {
        var id = await _products.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(Get), new { id }, new { productId = id });
    }
}
