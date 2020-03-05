using System;
using System.Collections.Generic;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.CustomerMediator.Queries.GetCustomers
{
    public class GetCustomersDTO : BaseDTO
    {
        public List<CustomerData> Data { get; set; }
    }
}
