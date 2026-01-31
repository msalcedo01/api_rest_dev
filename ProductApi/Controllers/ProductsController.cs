
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductAPI.Data;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDatabase _context;

        public ProductsController(AppDatabase context)
        {
            _context = context;
        }

        //Método GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if(product == null) return NotFound(new {error = "Product not found!"});

            return product;
        }
    }
}