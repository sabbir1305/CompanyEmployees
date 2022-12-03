using Entities.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Validation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            // Check name is not null, empty and is between 1 and 250 characters
            RuleFor(customer => customer.Name).NotNull().NotEmpty().Length(1, 60);
            RuleFor(customer => customer.Address).NotNull().NotEmpty().Length(1, 250);
        }
    }
}
