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
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Adınızı daxil edin !!!");
            RuleFor(x=>x.SurName).NotEmpty().WithMessage("Soyadınızı daxil edin !!!");
            RuleFor(x=>x.UserName).NotEmpty().WithMessage("İstifadəçi adını daxil edin !!!");
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Elektron poçtu daxil edin !!!");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Şifrəni daxil edin !!!");
            RuleFor(x=>x.ConfirmPassword).NotEmpty().WithMessage("Təkrar şifrəni daxil edin !!!");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Ən az 30 simvol daxil edilə bilər !!!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Ən az 3 simvol daxil edilə bilər !!!");
            RuleFor(x => x.ConfirmPassword).Equal(x=>x.Password).WithMessage("Təkrar şifrə ilə şifrə uyğun deyil !!!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Elektron poçt formatını düzgün daxil edin !!!");
        }
    }
}
