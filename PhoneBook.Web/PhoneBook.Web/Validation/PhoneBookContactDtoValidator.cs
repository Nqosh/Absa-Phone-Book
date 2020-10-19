using FluentValidation;
using PhoneBook.Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Web.Validation
{
    public class RegistrationViewModelValidator : AbstractValidator<PhoneBookContactDto>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(reg => reg.Name).NotEmpty().MinimumLength(4);
            RuleFor(reg => reg.Number).NotEmpty().MinimumLength(10);
            RuleFor(reg => reg.EntryType).NotEmpty();
        }
    }
}
