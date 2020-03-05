using System;
using MediatR;

namespace DecoratorPattern.Application.UseCases.ProductMediator.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<GetProductsDTO>
    {
    }
}
