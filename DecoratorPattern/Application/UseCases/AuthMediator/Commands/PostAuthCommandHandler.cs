using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DecoratorPattern.Application.UseCases.ProductMediator.Request;
using DecoratorPattern.Model;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DecoratorPattern.Application.UseCases.AuthMediator.Commands
{
    public class PostAuthCommandHandler : IRequestHandler<AuthCommand, AuthDTO>
    {
        private readonly IConfiguration _config;

        public PostAuthCommandHandler(IConfiguration config)
        {
            _config = config;
        }

        public async Task<AuthDTO> Handle(AuthCommand request, CancellationToken cancellationToken)
        {
            var user = AuthenticateUser(request);
            var tokenString = GenerateJSONWebToken(user);


            return new AuthDTO { Token = tokenString};
        }

        private Auth AuthenticateUser(Auth login)
        {
            var auth = new List<Auth>()
            {
                new Auth() { Username = "HambaAllah", Password = "rahasia" },
                new Auth() { Username = "userterdaftar", Password = "bandungsupermall" },
                new Auth() { Username = "user3", Password = "secret" },
            };

            Auth user = null;

            if (auth.Any(x => x.Username == login.Username) && auth.Any(x => x.Password == login.Password))
            {
                user = auth.First(x => x.Username == login.Username);
            }

            return user;
        }

        private string GenerateJSONWebToken(Auth userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
