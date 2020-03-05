using System;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Model;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DecoratorPattern.Application.UseCases.ProductMediator.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, GetProductsDTO>
    {
        private readonly ECommerceContext _context;

        public GetProductsQueryHandler(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<GetProductsDTO> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Products.ToListAsync();
            var result = new List<ProductData>();

            foreach(var x in data)
            {
                result.Add(new ProductData
                {
                    Id = x.Id,
                    Merchant_id = x.Merchant_id,
                    Name = x.Name,
                    Price = x.Price,
                });
            }

            return new GetProductsDTO
            {
                Message = "Success retrieving data",
                Success = true,
                Data = result
            };
        }
    }
}
