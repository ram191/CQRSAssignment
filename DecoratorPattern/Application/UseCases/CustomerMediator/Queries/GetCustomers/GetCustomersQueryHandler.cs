using System;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Model;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MimeKit;
using MailKit.Net.Smtp;
using Hangfire;

namespace DecoratorPattern.Application.UseCases.CustomerMediator.Queries.GetCustomers
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
            BackgroundJob.Enqueue(() => Console.WriteLine("Getting All Customer Data"));
            var data = await _context.Customers.ToListAsync();
            var result = new List<CustomerData>();

            foreach(var x in data)
            {
                result.Add(new CustomerData
                {
                    Id = x.Id,
                    Full_name = x.Full_name,
                    Username = x.Username,
                    Birthdate = x.Birthdate,
                    Password = x.Password,
                    Gender = Enum.GetName(typeof(Gender), x.Sex),
                    Email = x.Email,
                    Phone_number = x.Phone_number
                });
            }

            return new GetCustomersDTO
            {
                Message = "Success retrieving data",
                Success = true,
                Data = result
            };
        }
    }
}
