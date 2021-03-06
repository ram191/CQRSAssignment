﻿using System;
using DecoratorPattern.Application.UseCases.CustomerMediator.Queries.GetCustomers;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.CustomerMediator.Commands
{
    public class PutCustomerCommand : CommandDTO<Customer>, IRequest<GetCustomerDTO>
    {
    }
}
