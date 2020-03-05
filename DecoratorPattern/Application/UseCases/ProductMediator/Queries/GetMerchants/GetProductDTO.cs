using System;
using System.Collections.Generic;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.ProductMediator.Queries.GetProducts
{
    public class GetProductsDTO : BaseDTO
    {
        public List<ProductData> Data { get; set; }
    }
}
