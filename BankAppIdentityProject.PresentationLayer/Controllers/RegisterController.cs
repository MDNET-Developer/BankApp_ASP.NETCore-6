using BankAppIdentityProject.DtoLayer.Dtos.AppUserDtos;
using BankAppIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            if(ModelState.IsValid)
            {
                AppUser appUser = new()
                {
                    Name = registerDto.Name,
                    Surname = registerDto.SurName,
                    Email = registerDto.Email,
                    UserName = registerDto.UserName,

                };
               var result=  await _userManager.CreateAsync(appUser,password:registerDto.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index","ConfirmMail");
                }

            }
            return View();
        }
    }
}
