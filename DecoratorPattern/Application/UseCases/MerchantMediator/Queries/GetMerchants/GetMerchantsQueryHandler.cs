using System;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Model;
using MediatR;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DecoratorPattern.Application.UseCases.MerchantMediator.Queries.GetMerchants
{
    public class GetMerchantsQueryHandler : IRequestHandler<GetMerchantsQuery, GetMerchantsDTO>
    {
        private readonly ECommerceContext _context;

        public GetMerchantsQueryHandler(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<GetMerchantsDTO> Handle(GetMerchantsQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Merchants.ToListAsync();
            var result = new List<MerchantData>();

            foreach(var x in data)
            {
                result.Add(new MerchantData
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    Address = x.Address,
                    Rating = x.Rating,
                });
            }

            return new GetMerchantsDTO
            {
                Message = "Success retrieving data",
                Success = true,
                Data = result
            };
        }
    }
}
