using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public partial class ProductsController : ControllerBase
{
    private List<Product> _products = [
        new Product {Id = 1, Name = "product 1" },
        new Product {Id = 2, Name = "product 2" },
        new Product {Id = 3, Name = "product 3" },
        ];

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public IActionResult GetOne(int id)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);
        if (product != null)
        {
            return Ok(product);
        }
        return NotFound();
    }

}
