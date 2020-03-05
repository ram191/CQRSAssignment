using System;
using MediatR;

namespace DecoratorPattern.Application.UseCases.CustomerMediator.Queries.GetCustomers
{
    public class GetCustomerQuery : IRequest<GetCustomerDTO>
    {
        public int Id { get; set; }

        public GetCustomerQuery(int _id)
        {
            Id = _id;
        }
    }
}
