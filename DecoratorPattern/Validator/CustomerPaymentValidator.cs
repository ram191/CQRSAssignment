using System;
using DecoratorPattern.Model;
using FluentValidation;

namespace DecoratorPattern.Validator
{
    public class CustomerPaymentValidator : AbstractValidator<CommandDTO<CustomerPaymentCard>>
    {
        public CustomerPaymentValidator()
        {
            RuleFor(x => x.Data.Attributes.Name_on_card).NotEmpty().WithMessage("name_on_card can't be empty");
            RuleFor(x => x.Data.Attributes.Name_on_card).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => x.Data.Attributes.Exp_month).NotEmpty().WithMessage("exp_month can't be empty ");
            RuleFor(x => Convert.ToInt32(x.Data.Attributes.Exp_month)).ExclusiveBetween(1, 12).WithMessage("exp_month is bettween 1-12");
            RuleFor(x => x.Data.Attributes.Exp_year).NotEmpty().WithMessage("exp_year can't be empty ");
            RuleFor(x => x.Data.Attributes.Credit_card_number).CreditCard().WithMessage("credit_card_number must be type of credit card number");
        }
    }
}
