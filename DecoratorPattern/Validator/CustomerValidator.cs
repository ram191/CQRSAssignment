using System;
using DecoratorPattern.Model;
using FluentValidation;

namespace DecoratorPattern.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("username can't be empty");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("max username length is 20");
            RuleFor(x => x.Email).NotEmpty().WithMessage("email can't be empty");
            RuleFor(x => x.Email).EmailAddress().WithMessage("email is not valid email address");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("gender can't be empty");
            RuleFor(x => x.Gender).IsInEnum().WithMessage("gender is one of male or female");
            RuleFor(x => x.Birthdate).NotEmpty().WithMessage("birthdate can't be empty");
        }
    }
}
