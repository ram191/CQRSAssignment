using System;
using MediatR;

namespace DecoratorPattern.Application.UseCases.CustomerMediator.Queries.GetCustomers
{
    public class GetCustomersQuery : IRequest<GetCustomersDTO>
    {
    }
}
