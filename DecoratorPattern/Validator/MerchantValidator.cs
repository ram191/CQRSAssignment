using System;
using DecoratorPattern.Model;
using FluentValidation;

namespace DecoratorPattern.Validator
{
    public class MerchantValidator : AbstractValidator<Merchant>
    {
        public MerchantValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.Address).NotEmpty().WithMessage("address can't be empty");
            RuleFor(x => x.Rating).InclusiveBetween(1, 5).WithMessage("rating is between 1-5");
        }
    }
}
