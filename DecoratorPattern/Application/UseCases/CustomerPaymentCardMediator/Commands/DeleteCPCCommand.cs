using System;
using DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Request;
using DecoratorPattern.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Commands
{
    public class DeleteCustomerPaymentCardCommand : IRequest<CustomerPaymentCardDTO>
    {
        public int Id { get; set; }

        public DeleteCustomerPaymentCardCommand(int id)
        {
            Id = id;
        }
    }
}
