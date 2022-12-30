using Entities.DataTransferObjects.Companies;
using Entities.DataTransferObjects.Employees;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Validation.DTOValidations
{
    public class CompanyForManipulationDtoValidator : AbstractValidator<CompanyForManipulationDto>
    {
        public CompanyForManipulationDtoValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty().WithMessage(ValidationMessages.RequiredMessage("Company name"));
            RuleFor(model => model.Address).NotNull().NotEmpty().WithMessage(ValidationMessages.RequiredMessage("Address"));
            RuleFor(model => model.Country).NotNull().NotEmpty().WithMessage(ValidationMessages.RequiredMessage("Country"));

        }
    }
}
