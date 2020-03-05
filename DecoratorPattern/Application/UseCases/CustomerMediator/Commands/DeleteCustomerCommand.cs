using System;
using DecoratorPattern.Application.UseCases.CustomerMediator.Request;
using DecoratorPattern.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorPattern.Application.UseCases.CustomerMediator.Commands
{
    public class DeleteCustomerCommand : IRequest<CustomerDTO>
    {
        public int Id { get; set; }

        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
