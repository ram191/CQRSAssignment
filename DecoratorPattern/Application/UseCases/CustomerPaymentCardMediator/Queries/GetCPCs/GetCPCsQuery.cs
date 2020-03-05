using System;
using MediatR;

namespace DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Queries.GetCPCs
{
    public class GetCustomerPaymentCardsQuery : IRequest<GetCustomerPaymentCardsDTO>
    {
    }
}
