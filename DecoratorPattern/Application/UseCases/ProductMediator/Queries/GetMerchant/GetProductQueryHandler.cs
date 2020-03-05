using System;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Model;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DecoratorPattern.Application.UseCases.ProductMediator.Queries.GetProducts
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductDTO>
    {
        private readonly ECommerceContext _context;

        public GetProductQueryHandler(ECommerceContext context)
        {
            _context = context;
        }

        async Task<GetProductDTO> IRequestHandler<GetProductQuery, GetProductDTO>.Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Products.FindAsync(request.Id);

            if (data == null)
            {
                data = null;
            }

            return new GetProductDTO
            {
                Message = "Success retreiving data",
                Success = true,
                Data = new ProductData {
                    Id = data.Id,
                    Merchant_id = data.Merchant_id,
                    Name = data.Name,
                    Price = data.Price,
                }
            };

        }
    }
}
