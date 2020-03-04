using System;
using MediatR;

namespace DecoratorPattern.Application.UseCases.Product.Queries.GetCustomers
{
    public class GetCustomersQuery : IRequest<GetCustomersDTO>
    {
    }
}
