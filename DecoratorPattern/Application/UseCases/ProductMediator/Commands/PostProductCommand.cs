using System;
using DecoratorPattern.Application.UseCases.ProductMediator.Queries.GetProducts;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.ProductMediator.Commands
{
    public class ProductCommand : CommandDTO<Product>, IRequest<GetProductDTO>
    {
    }
}
