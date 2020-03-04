//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using DecoratorPattern.Model;
//using Microsoft.Extensions.Logging;
//using Microsoft.AspNetCore.Authorization;

//namespace DecoratorPattern.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    [Authorize]
//    public class MerchantController : ControllerBase
//    {
//        private readonly ILogger<MerchantController> _logger;
//        private readonly ECommerceContext _context;

//        public MerchantController(ILogger<MerchantController> logger, ECommerceContext context)
//        {
//            _logger = logger;
//            _context = context;
//        }

//        [HttpGet]
//        public IActionResult Get()
//        {
//            return Ok(new { Message = "Success retreiving data", Status = true, Data = _context.Merchants });
//        }

//        [HttpGet("{id}")]
//        public IActionResult Get(int id)
//        {
//            var data = _context.Merchants.Find(id);

//            if (data == null)
//            {
//                return NotFound(new { Message = "Product not found", Status = false });
//            }

//            return Ok(new { Message = "Success retreiving data", Status = true, Data = data });
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            var data = await _context.Merchants.FindAsync(id);

//            if (data == null)
//            {
//                return NotFound(new { Message = "Product not found", Status = false });
//            }

//            _context.Merchants.Remove(data);
//            await _context.SaveChangesAsync();

//            return StatusCode(204);
//        }

//        [HttpPost]
//        public IActionResult Post(RequestData<Merchant> data)
//        {
//            _context.Merchants.Add(data.Data.Attributes);
//            _context.SaveChanges();
//            return Ok();
//        }

//        [HttpPut("{id}")]
//        public IActionResult Put(int id, RequestData<Merchant> data)
//        {
//            var query = _context.Merchants.Find(id);
//            query.Name = data.Data.Attributes.Name;
//            query.Image = data.Data.Attributes.Image;
//            query.Address = data.Data.Attributes.Address;
//            query.Rating = data.Data.Attributes.Rating;
//            query.Updated_at = data.Data.Attributes.Updated_at;
//            _context.SaveChanges();
//            return NoContent();
//        }
//    }
//}
