using Microsoft.AspNetCore.Identity;

namespace BankAppIdentityProject.PresentationLayer.Models
{
	public class CustomIdentityValidator:IdentityErrorDescriber
	{
		//program.cs bax
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = nameof(PasswordTooShort),
				Description = $"Uzunluq: {length}  olmalıdır"
			};
		}

		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code= nameof(PasswordRequiresUpper),
				Description="Ən az 1 böyük hərf daxil edin."
			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code = nameof(PasswordRequiresLower),
				Description = "Ən az 1 kiçik hərf daxil edin."
			};
		}

		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError()
			{
				Code = nameof(PasswordRequiresDigit),
				Description = "Ən az 1 ədəd rəqəm daxil edin"
			};
		}

		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = nameof(PasswordRequiresNonAlphanumeric),
				Description = "Ən az 1 simvol daxil edin/@#$%^&*!~"
			};
		}

		public override IdentityError InvalidEmail(string email)
		{
			return new IdentityError()
			{
				Code =nameof(InvalidEmail),
				Description = "E-poçt düzgün deyil"
			};
		}

		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError()
			{
				Code =nameof(DuplicateEmail),
				Description = $"{email} bu mail artıq istifadə olunub"
			};
		}
	}
}
