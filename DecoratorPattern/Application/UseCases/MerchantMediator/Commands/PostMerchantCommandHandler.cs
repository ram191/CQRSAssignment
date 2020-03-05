using System;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Application.UseCases.MerchantMediator.Queries.GetMerchants;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.MerchantMediator.Commands
{
    public class PostMerchantCommandHandler : IRequestHandler<MerchantCommand, GetMerchantDTO>
    {
        private readonly ECommerceContext _context;

        public PostMerchantCommandHandler(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<GetMerchantDTO> Handle(MerchantCommand request, CancellationToken cancellationToken)
        {
            _context.Merchants.Add(request.Data.Attributes);
            await _context.SaveChangesAsync();

            return new GetMerchantDTO
            {
                Message = "Successfully Added",
                Success = true,
                Data = new MerchantData
                {
                    Id = request.Data.Attributes.Id,
                    Address = request.Data.Attributes.Address,
                    Image = request.Data.Attributes.Image,
                    Name = request.Data.Attributes.Name,
                    Rating = request.Data.Attributes.Rating,
                }
            };
        }
    }
}
