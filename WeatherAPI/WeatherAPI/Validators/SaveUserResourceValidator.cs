using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherAPI.Resources;
using WeatherData;

namespace WeatherAPI.Validators
{
    public class SaveUserResourceValidator : AbstractValidator<SaveUserResource>
    {
        public SaveUserResourceValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty();
            RuleFor(u => u.Email)
               .NotEmpty()
               .EmailAddress(mode: FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
        }
    }

}
