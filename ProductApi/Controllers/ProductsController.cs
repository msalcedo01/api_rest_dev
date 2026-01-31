
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //Método POST
        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] Product product)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetById), new {id = product.Id}, product);
        }
        //Método UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            //if(id!=product.Id) return BadRequest(new {error = "ID not found!"});
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var exists = await _context.Products.FindAsync(id);
            if(exists==null) return NotFound(new {error = "Product not found!"});

            //_context.Entry(product).State = EntityState.Modified;
            
            exists.Nombre = product.Nombre;
            exists.Precio = product.Precio;
            exists.Categoria = product.Categoria;
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Método DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product==null) return NotFound(new {error = "Product not found!"});

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}