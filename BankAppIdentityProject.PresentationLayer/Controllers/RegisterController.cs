using BankAppIdentityProject.DtoLayer.Dtos.AppUserDtos;
using BankAppIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BankAppIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto registerDto)
		{
			var existingUserName = await _userManager.FindByNameAsync(registerDto.UserName);
			var existingUserMail = await _userManager.FindByEmailAsync(registerDto.Email);
			if (existingUserName != null)
			{
				ModelState.AddModelError(string.Empty, $"{registerDto.UserName} bu istifadəçi adı artıq istifadə olunur.");
				return View(registerDto);
			}
			if (existingUserMail != null)
			{
				ModelState.AddModelError(string.Empty, $"{registerDto.Email} bu mail artıq istifadə olunur.");
				return View(registerDto);
			}

			

			if (ModelState.IsValid)
            {
                Random random = new();
                AppUser appUser = new()
                {
                    Name = registerDto.Name,
                    Surname = registerDto.SurName,
                    Email = registerDto.Email,
                    UserName = registerDto.UserName,
                    ConfirmCode = random.Next(100000, 1000000)

                };
               var result=  await _userManager.CreateAsync(appUser,password:registerDto.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","ConfirmMail");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }

            }
                return View();
           
           
        }
    }
}
