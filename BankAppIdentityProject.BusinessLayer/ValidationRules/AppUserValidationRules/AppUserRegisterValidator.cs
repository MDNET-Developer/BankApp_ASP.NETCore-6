using BankAppIdentityProject.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Verilən daxil edin !!!");
            RuleFor(x=>x.SurName).NotEmpty().WithMessage("Verilən daxil edin !!!");
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("Verilən daxil edin !!!");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Verilən daxil edin !!!");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Verilən daxil edin !!!");
            RuleFor(x=>x.ConfirmPassword).NotEmpty().WithMessage("Verilən daxil edin !!!");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Ən az 30 simvol daxil edilə bilər !!!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ən az 3 simvol daxil edilə bilər !!!");
        }
    }
}
