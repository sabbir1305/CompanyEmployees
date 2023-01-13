using Entities.DataTransferObjects.UserManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Validation.DTOValidations
{

    public class UserForRegistrationDtoValidator : AbstractValidator<UserForRegistrationDto>
    {
        public UserForRegistrationDtoValidator()
        {
            RuleFor(model => model.UserName).NotNull().NotEmpty().WithMessage(ValidationMessages.RequiredMessage("User name"));
            RuleFor(model => model.Password).NotNull().NotEmpty().WithMessage(ValidationMessages.RequiredMessage("Password"));
         
          
    }
}
