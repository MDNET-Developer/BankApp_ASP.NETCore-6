using BankAppIdentityProject.EntityLayer.Concrete;
using BankAppIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankAppIdentityProject.PresentationLayer.Controllers
{
    public class LogInController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LogInController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LogInViewModel logInViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(logInViewModel.username,logInViewModel.password,logInViewModel.rememberme,true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(logInViewModel.username);
                if (user.EmailConfirmed.Equals(true))
                {
                    return RedirectToAction("Index","");
                }
            }
            return View();
        }
    }
}
