using System;
using MediatR;

namespace DecoratorPattern.Application.UseCases.MerchantMediator.Queries.GetMerchants
{
    public class GetMerchantsQuery : IRequest<GetMerchantsDTO>
    {
    }
}
