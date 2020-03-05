using System;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Application.UseCases.ProductMediator.Request;
using DecoratorPattern.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorPattern.Application.UseCases.ProductMediator.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDTO>
    {
        private readonly ECommerceContext _context;

        public DeleteProductCommandHandler(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<ProductDTO> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Products.FindAsync(request.Id);

            if (data == null)
            {
                return null;
            }

            _context.Products.Remove(data);
            await _context.SaveChangesAsync();

            return new ProductDTO { Message = "Successfull", Success = true };
        }
    }
}
