using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DecoratorPattern.Model;
using Microsoft.Extensions.Logging;

namespace DecoratorPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ECommerceContext _context;

        public ProductController(ILogger<ProductController> logger, ECommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Success retreiving data", Status = true, Data = _context.Products });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Products.Find(id);

            if (data == null)
            {
                return NotFound(new { Message = "Product not found", Status = false });
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Products.FindAsync(id);

            if (data == null)
            {
                return NotFound(new { Message = "Product not found", Status = false });
            }

            _context.Products.Remove(data);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(RequestData<Product> data)
        {
            _context.Products.Add(data.Data.Attributes);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, RequestData<Product> data)
        { 
            var query = _context.Products.Find(id);
            query.Name = data.Data.Attributes.Name;
            query.Price = data.Data.Attributes.Price;
            query.Updated_at = DateTime.Now;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
