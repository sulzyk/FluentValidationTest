using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTest
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator(IUserRepository userRepository)
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Nazwa jest wymagana");

            RuleFor(u => u.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .EmailAddress()
                .Must(email => userRepository.Exist(email) == false)
                .WithMessage("Email musi byc unikalny");

            //RuleFor(u => u.Nip)
            //    .NotEmpty()
            //    .When(u => u.CreateInvoice);
            When(u => u.CreateInvoice, () =>
            {
                RuleFor(u => u.Nip)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                //.Must(nip => IsNipValid(nip));
                .Nip();
            });
            //korzystanie z validatora z AddressValidator
            RuleFor(u => u.Address)
                .SetValidator(new AddressValidator());

            RuleForEach(u => u.Order)
                .SetValidator(new OrderValidator());

        }

        private bool IsNipValid(string nip)
        {
            if (nip == null)
            {
                return false;
            }

            if (nip.Length != 10)
            {
                return false;
            }

            return true;

        }
    }
}
