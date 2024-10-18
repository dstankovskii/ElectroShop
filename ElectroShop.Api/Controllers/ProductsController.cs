using ElectroShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectroShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    // Example product data
    private static readonly List<Product> Products = new List<Product>
    {
        new Product { Id = 1, Name = "Smartphone", Price = 599.99m, Description = "Latest model with high performance" },
        new Product { Id = 2, Name = "Laptop", Price = 1299.99m, Description = "Powerful laptop with 16GB RAM" },
        new Product { Id = 3, Name = "Wireless Headphones", Price = 199.99m, Description = "Noise-cancelling headphones" }
    };

    // Method to get all products
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAllProducts()
    {
        return Ok(Products);
    }

    // Method to get product details by ID
    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound(new { message = "Product not found" });
        }

        return Ok(product);
    }
}
