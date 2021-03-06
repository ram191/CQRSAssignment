﻿using System;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Model;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using System.Net.Mail;
using System.Net;

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
            //BackgroundJob.Enqueue(() => Console.WriteLine("Getting A Customer Data"));

            var data = await _context.Customers.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }
            else
            {
                return new GetCustomerDTO
                {
                    Message = "Success retreiving data",
                    Success = true,
                    Data = new CustomerData
                    {
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
}
