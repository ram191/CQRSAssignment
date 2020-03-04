using System;
using System.Collections.Generic;
using DecoratorPattern.Application.UseCases.Product.Models;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.Product.Queries.GetCustomers
{
    public class GetCustomersDTO : BaseDTO
    {
        public IList<Customer> Data { get; set; }
    }
}
