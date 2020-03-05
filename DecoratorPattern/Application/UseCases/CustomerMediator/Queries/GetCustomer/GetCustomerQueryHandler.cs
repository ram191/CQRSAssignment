using System;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Model;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DecoratorPattern.Application.UseCases.CustomerMediator.Queries.GetCustomers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerDTO>
    {
        private readonly ECommerceContext _context;

        public GetCustomerQueryHandler(ECommerceContext context)
        {
            _context = context;
        }

        async Task<GetCustomerDTO> IRequestHandler<GetCustomerQuery, GetCustomerDTO>.Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Customers.FindAsync(request.Id);

            if (data == null)
            {
                data = null;
            }

            return new GetCustomerDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new CustomerData {
                    Id = data.Id,
                    Full_name = data.Full_name,
                    Username = data.Username,
                    Birthdate = data.Birthdate,
                    Password = data.Password,
                    Gender = Enum.GetName(typeof(Gender), data.Sex),
                    Email = data.Email,
                    Phone_number = data.Phone_number
                }
            };

        }
    }
}
