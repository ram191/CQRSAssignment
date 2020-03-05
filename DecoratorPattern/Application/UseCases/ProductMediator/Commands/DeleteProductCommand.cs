using System;
using DecoratorPattern.Application.UseCases.ProductMediator.Request;
using DecoratorPattern.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorPattern.Application.UseCases.ProductMediator.Commands
{
    public class DeleteProductCommand : IRequest<ProductDTO>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
