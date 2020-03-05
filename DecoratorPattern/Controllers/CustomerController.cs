using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DecoratorPattern.Model;
using Microsoft.Extensions.Logging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DecoratorPattern.Application.UseCases.CustomerMediator.Queries.GetCustomers;
using DecoratorPattern.Application.UseCases.CustomerMediator.Commands;

namespace DecoratorPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediatr;

        public CustomerController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<GetCustomersDTO>> Get()
        {
            var result = new GetCustomersQuery();
            return Ok(await _mediatr.Send(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = new GetCustomerQuery(id);
            return result != null ? (IActionResult)Ok(await _mediatr.Send(result)) : NotFound(new { Message = "Customer not found" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCustomerCommand(id);
            var result = await _mediatr.Send(command);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound( new { Message = "Customer not found"});
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CustomerCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CustomerCommand data)
        {
            data.Data.Attributes.Id = id;
            var result = await _mediatr.Send(data);
            return Ok(result);


        }
    }
}
