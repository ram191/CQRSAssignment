using System;
using DecoratorPattern.Model;
using FluentValidation;

namespace DecoratorPattern.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => x.Price).NotEmpty().WithMessage("price can't be empty ");
            RuleFor(x => x.Price).GreaterThan(1000).WithMessage("email is not valid email address");
        }
    }
}
