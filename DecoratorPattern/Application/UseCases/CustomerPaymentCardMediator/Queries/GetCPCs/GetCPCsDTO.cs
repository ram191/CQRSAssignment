using System;
using System.Collections.Generic;
using DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Queries.GetCPC;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Queries.GetCPCs
{
    public class GetCustomerPaymentCardsDTO : BaseDTO
    {
        public List<CustomerPaymentCardData> Data { get; set; }
    }
}
