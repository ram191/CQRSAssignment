using System;
using System.Collections.Generic;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.ProductMediator.Queries.GetProducts
{
    public class GetProductDTO : BaseDTO
    {
        public ProductData Data { get; set; }
    }

    public class ProductData
    {
        public int Id { get; set; }
        public int Merchant_id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
