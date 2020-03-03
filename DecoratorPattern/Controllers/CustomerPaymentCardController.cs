using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DecoratorPattern.Model;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace DecoratorPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomerPaymentCardController : ControllerBase
    {
        private readonly ILogger<CustomerPaymentCardController> _logger;
        private readonly ECommerceContext _context;

        public CustomerPaymentCardController(ILogger<CustomerPaymentCardController> logger, ECommerceContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Success retreiving data", Status = true, Data = _context.CustomerPaymentCards });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.CustomerPaymentCards.Find(id);

            if (data == null)
            {
                return NotFound(new { Message = "Product not found", Status = false });
            }

            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _context.CustomerPaymentCards.FindAsync(id);

            if (data == null)
            {
                return NotFound(new { Message = "Product not found", Status = false });
            }

            _context.CustomerPaymentCards.Remove(data);
            await _context.SaveChangesAsync();

            return StatusCode(204);
        }

        [HttpPost]
        public IActionResult Post(CustomerPaymentCard data)
        {
            _context.CustomerPaymentCards.Add(data);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, CustomerPaymentCard data)
        {
            var query = _context.CustomerPaymentCards.Find(id);
            query.Name_on_card = data.Name_on_card;
            query.Exp_month = data.Exp_month;
            query.Exp_year = data.Exp_year;
            query.Postal_code = data.Postal_code;
            query.Credit_card_number = data.Credit_card_number;
            query.Updated_at = data.Updated_at;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
