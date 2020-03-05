using System;
using DecoratorPattern.Application.UseCases.MerchantMediator.Queries.GetMerchants;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.MerchantMediator.Commands
{
    public class MerchantCommand : CommandDTO<Merchant>, IRequest<GetMerchantDTO>
    {
    }
}
