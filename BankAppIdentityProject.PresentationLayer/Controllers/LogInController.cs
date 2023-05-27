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
            var resault = await _signInManager.PasswordSignInAsync(logInViewModel.username,logInViewModel.password,logInViewModel.rememberme,true);
            return View();
        }
    }
}
