using System;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Application.UseCases.CustomerMediator.Queries.GetCustomers;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.CustomerMediator.Commands
{
    public class PutCustomerCommandHandler : IRequestHandler<CustomerCommand, GetCustomerDTO>
    {
        private readonly ECommerceContext _context;

        public PutCustomerCommandHandler(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<GetCustomerDTO> Handle(CustomerCommand request, CancellationToken cancellationToken)
        {
            var query = await _context.Customers.FindAsync(request.Data.Attributes.Id);
            query.Full_name = request.Data.Attributes.Full_name;
            query.Username = request.Data.Attributes.Username;
            query.Birthdate = request.Data.Attributes.Birthdate;
            query.Email = request.Data.Attributes.Email;
            query.Phone_number = request.Data.Attributes.Phone_number;
            query.Updated_at = DateTime.Now;
            _context.SaveChanges();
            return new GetCustomerDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new CustomerData
                {
                    Id = query.Id,
                    Full_name = query.Full_name,
                    Username = query.Username,
                    Birthdate = query.Birthdate,
                    Password = query.Password,
                    Gender = Enum.GetName(typeof(Gender), query.Sex),
                    Email = query.Email,
                    Phone_number = query.Phone_number
                }
            };
        }
    }
}
