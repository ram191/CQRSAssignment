using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FluentValidation;
using DecoratorPattern.Validator;
using DecoratorPattern.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Reflection;
using DecoratorPattern.Application.UseCases.CustomerMediator.Queries.GetCustomers;
using DecoratorPattern.Application.UseCases.CustomerMediator.Commands;
using DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Queries.GetCPC;
using DecoratorPattern.Application.UseCases.CustomerPaymentCardMediator.Commands;
using DecoratorPattern.Application.UseCases.ProductMediator.Commands;
using DecoratorPattern.Application.UseCases.MerchantMediator.Commands;

namespace DecoratorPattern
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ECommerceContext>(opt
                => opt.UseNpgsql("Host=localhost;Database=ecommercedb;Username=postgres;Password=gigaming"));
            services.AddControllers();

            services.AddMediatR(typeof(GetCustomerQueryHandler).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetCustomerPaymentCardQueryHandler).GetTypeInfo().Assembly);
            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidator<CustomerCommand>, CustomerValidator>();
            services.AddTransient<IValidator<PutCustomerCommand>, CustomerValidator>();
            services.AddTransient<IValidator<CustomerPaymentCardCommand>, CustomerPaymentValidator>();
            services.AddTransient<IValidator<PutCustomerPaymentCardCommand>, CustomerPaymentValidator>();
            services.AddTransient<IValidator<ProductCommand>, ProductValidator>();
            services.AddTransient<IValidator<PutProductCommand>, ProductValidator>();
            services.AddTransient<IValidator<MerchantCommand>, MerchantValidator>();
            services.AddTransient<IValidator<PutMerchantCommand>, MerchantValidator>();


            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidator<,>));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
