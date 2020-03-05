using System;
using DecoratorPattern.Application.UseCases.MerchantMediator.Request;
using DecoratorPattern.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DecoratorPattern.Application.UseCases.MerchantMediator.Commands
{
    public class DeleteMerchantCommand : IRequest<MerchantDTO>
    {
        public int Id { get; set; }

        public DeleteMerchantCommand(int id)
        {
            Id = id;
        }
    }
}
