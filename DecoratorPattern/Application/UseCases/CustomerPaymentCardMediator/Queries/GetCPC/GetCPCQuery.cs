using System;
using MediatR;

namespace DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Queries.GetCPC
{
    public class GetCustomerPaymentCardQuery : IRequest<GetCustomerPaymentCardDTO>
    {
        public int Id { get; set; }

        public GetCustomerPaymentCardQuery(int _id)
        {
            Id = _id;
        }
    }
}
