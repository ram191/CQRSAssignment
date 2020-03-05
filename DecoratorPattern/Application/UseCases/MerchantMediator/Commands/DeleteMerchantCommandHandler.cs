using System;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Application.UseCases.MerchantMediator.Request;
using DecoratorPattern.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorPattern.Application.UseCases.MerchantMediator.Commands
{
    public class DeleteMerchantCommandHandler : IRequestHandler<DeleteMerchantCommand, MerchantDTO>
    {
        private readonly ECommerceContext _context;

        public DeleteMerchantCommandHandler(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<MerchantDTO> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Merchants.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.Merchants.Remove(data);
            await _context.SaveChangesAsync();

            return new MerchantDTO { Message = "Successfull", Success = true };
        }
    }
}
