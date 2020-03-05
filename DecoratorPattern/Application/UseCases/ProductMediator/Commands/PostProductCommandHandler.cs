using System;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Application.UseCases.ProductMediator.Queries.GetProducts;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.ProductMediator.Commands
{
    public class PostProductCommandHandler : IRequestHandler<ProductCommand, GetProductDTO>
    {
        private readonly ECommerceContext _context;

        public PostProductCommandHandler(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<GetProductDTO> Handle(ProductCommand request, CancellationToken cancellationToken)
        {
            _context.Products.Add(request.Data.Attributes);
            await _context.SaveChangesAsync();

            return new GetProductDTO
            {
                Message = "Successfully Added",
                Success = true,
                Data = new ProductData
                {
                    Id = request.Data.Attributes.Id,
                    Merchant_id = request.Data.Attributes.Merchant_id,
                    Name = request.Data.Attributes.Name,
                    Price = request.Data.Attributes.Price,
                }
            };
        }
    }
}
