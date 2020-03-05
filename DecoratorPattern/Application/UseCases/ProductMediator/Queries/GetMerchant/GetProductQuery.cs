using System;
using MediatR;

namespace DecoratorPattern.Application.UseCases.ProductMediator.Queries.GetProducts
{
    public class GetProductQuery : IRequest<GetProductDTO>
    {
        public int Id { get; set; }

        public GetProductQuery(int _id)
        {
            Id = _id;
        }
    }
}
