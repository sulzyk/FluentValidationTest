using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationTest
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(u => u.Product)
                .NotEmpty();
            RuleFor(u => u.Price)
                .GreaterThan(0);
        }
    }
}
