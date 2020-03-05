using System;
using MediatR;

namespace DecoratorPattern.Application.UseCases.MerchantMediator.Queries.GetMerchants
{
    public class GetMerchantQuery : IRequest<GetMerchantDTO>
    {
        public int Id { get; set; }

        public GetMerchantQuery(int _id)
        {
            Id = _id;
        }
    }
}
