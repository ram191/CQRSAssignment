using System;
using DecoratorPattern.Application.UseCases.ProductMediator.Request;
using DecoratorPattern.Model;
using MediatR;

namespace DecoratorPattern.Application.UseCases.AuthMediator.Commands
{
    public class AuthCommand : Auth, IRequest<AuthDTO>
    {
    }

    public class Auth
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
