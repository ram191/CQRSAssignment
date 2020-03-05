using System;
using DecoratorPattern.Application.UseCases.CustomerMediator.Queries.GetCustomers;
using DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Queries.GetCPC;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Commands
{
    public class PutCustomerPaymentCardCommand : CommandDTO<CustomerPaymentCard>, IRequest<GetCustomerPaymentCardDTO>
    {
    }
}
