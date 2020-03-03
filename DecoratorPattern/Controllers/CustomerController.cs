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
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ECommerceContext _context;

        public CustomerController(ILogger<CustomerController> logger, ECommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<object> allData = new List<object>();
            var data = _context.Customers;
            foreach (var x in data)
            {
                allData.Add(new { x.Id, x.Full_name, x.Username, x.Email, x.Phone_number, gender = Enum.GetName(typeof(Gender), x.Gender)});
            }
            return Ok(new { Message = "Success retreiving data", Status = true, Data = allData });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Customers.Find(id);

            if (data == null)
            {
                return NotFound(new { Message = "Customer not found", Status = false });
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.Customers.FindAsync(id);

            if (data == null)
            {
                return NotFound(new { Message = "Customer not found", Status = false });
            }

            _context.Customers.Remove(data);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(Customer data)
        {
            _context.Customers.Add(data);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Customer data)
        {
            var query = _context.Customers.Find(id);
            query.Full_name = data.Full_name;
            query.Username = data.Username;
            query.Birthdate = data.Birthdate;
            query.Email = data.Email;
            query.Phone_number = data.Phone_number;
            query.Updated_at = DateTime.Now;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
