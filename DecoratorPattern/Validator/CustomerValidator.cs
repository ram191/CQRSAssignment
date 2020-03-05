using System;
using System.Collections.Generic;
using System.Linq;
using DecoratorPattern.Model;
using FluentValidation;

namespace DecoratorPattern.Validator
{
    public class CustomerValidator : AbstractValidator<CommandDTO<Customer>>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Data.Attributes.Username).NotEmpty().WithMessage("username can't be empty");
            RuleFor(x => x.Data.Attributes.Username).MaximumLength(20).WithMessage("max username length is 20");
            RuleFor(x => x.Data.Attributes.Email).NotEmpty().WithMessage("email can't be empty");
            RuleFor(x => x.Data.Attributes.Email).EmailAddress().WithMessage("email is not valid email address");
            RuleFor(x => x.Data.Attributes.Gender).NotEmpty().WithMessage("gender can't be empty");
            RuleFor(x => x.Data.Attributes.Gender).Must(x => x == "male" || x == "female").WithMessage("Gender must be of male or female");
            RuleFor(x => x.Data.Attributes.Birthdate).NotEmpty().WithMessage("birthdate can't be empty");
            RuleFor(x => x.Data.Attributes.Birthdate).Must(x => DateTime.Now.Year - x.Year > 17).WithMessage("Age must be greater than 18 years old");
        }
    }
}
