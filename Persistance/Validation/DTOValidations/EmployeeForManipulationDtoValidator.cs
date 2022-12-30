using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Employees;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Validation.DTOValidations
{
    public class EmployeeForManipulationDtoValidator : AbstractValidator<EmployeeForManipulationDto>
    {
        public EmployeeForManipulationDtoValidator()
        {
            RuleFor(model => model.Name).NotNull().NotEmpty().WithMessage(ValidationMessages.RequiredMessage("Employee name"));
            RuleFor(model => model.Name).MaximumLength(30).WithMessage(ValidationMessages.MaxLengthMessage("Employee name", 30));
            RuleFor(model => model.Position).NotNull().NotEmpty().WithMessage(ValidationMessages.RequiredMessage("Position"));
            RuleFor(model => model.Position).MaximumLength(20).WithMessage(ValidationMessages.MaxLengthMessage("Position", 20));
            RuleFor(model => model.Age).GreaterThanOrEqualTo(18).WithMessage(ValidationMessages.RangeMessage("Age", 18));
            RuleFor(model => model.Age).NotNull().NotEmpty().WithMessage(ValidationMessages.RequiredMessage("Age"));
        }
    }
}
