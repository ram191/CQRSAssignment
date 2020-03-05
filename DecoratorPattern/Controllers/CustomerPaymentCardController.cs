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
using MediatR;
using DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Queries.GetCPCs;
using DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Queries.GetCPC;
using DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Commands;

namespace DecoratorPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomerPaymentCardController : ControllerBase
    {
        private IMediator _mediatr;

        public CustomerPaymentCardController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<ActionResult<GetCustomerPaymentCardsDTO>> Get()
        {
            var result = new GetCustomerPaymentCardsQuery();
            return Ok(await _mediatr.Send(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = new GetCustomerPaymentCardQuery(id);
            return result != null ? (IActionResult)Ok(await _mediatr.Send(result)) : NotFound(new { Message = "Customer not found" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCustomerPaymentCardCommand(id);
            var result = await _mediatr.Send(command);
            return result != null ? (IActionResult)Ok(new { Message = "success" }) : NotFound(new { Message = "Customer not found" });
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CustomerPaymentCardCommand data)
        {
            var result = await _mediatr.Send(data);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CustomerPaymentCardCommand data)
        {
            data.Data.Attributes.Id = id;
            var result = await _mediatr.Send(data);
            return Ok(result);
        }
    }
}
