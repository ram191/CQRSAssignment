using System;
using System.Collections.Generic;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.MerchantMediator.Queries.GetMerchants
{
    public class GetMerchantsDTO : BaseDTO
    {
        public List<MerchantData> Data { get; set; }
    }
}
