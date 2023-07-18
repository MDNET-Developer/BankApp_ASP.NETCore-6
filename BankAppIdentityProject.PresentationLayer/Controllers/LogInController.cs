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
            var userName = await _userManager.FindByNameAsync(logInViewModel.username);
            var result = await _signInManager.PasswordSignInAsync(logInViewModel.username, logInViewModel.password, logInViewModel.rememberme, lockoutOnFailure: true);


            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(logInViewModel.username);
                if (user.EmailConfirmed.Equals(true))
                {
                    return RedirectToAction("Index", "MyProfile");
                }
                else
                {
                    TempData["Mail"] = user.Email;
                    return RedirectToAction("Index", "ConfirmMail");
                }
            }
            else
            {
                if (userName.Equals(null))
                {
                    ModelState.AddModelError("", $"İstifadəçi adın vəya şifrə xətalı");
                }
                else
                {
                    var failedCount = await _userManager.GetAccessFailedCountAsync(userName);
                    var maxFailedCount = _userManager.Options.Lockout.MaxFailedAccessAttempts;
                    ModelState.AddModelError("", $"{maxFailedCount - failedCount} dəfə  səhv etsəz hesabınız ban olacaq keçici olaraq");
                }

            }
            return View();
        }


    }
}
