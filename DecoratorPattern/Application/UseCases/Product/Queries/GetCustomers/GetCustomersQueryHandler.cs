using System;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Model;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DecoratorPattern.Application.UseCases.Product.Models;

namespace DecoratorPattern.Application.UseCases.Product.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersDTO>
    {
        private readonly ECommerceContext _context;

        public GetCustomersQueryHandler(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<GetCustomersDTO> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Customers.ToListAsync();

            var result = data.Select(c => new CustomerData
            {
                Full_name = c.Full_name,
                Username = c.Username,
                Birthdate = c.Birthdate,
                Password = c.Password,
                Gender = Enum.GetName(typeof(Model.Gender), c.Sex),
                Email = c.Email,
                Phone_number = c.Phone_number
            });

            return new GetCustomersDTO
            {
                Message = "Success retrieving data",
                Success = true,
                Data = result.ToList()
            };
        }
    }
}
