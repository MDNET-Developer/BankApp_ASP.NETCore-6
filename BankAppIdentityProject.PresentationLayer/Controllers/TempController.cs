using BankAppIdentityProject.EntityLayer.Concrete;
using BankAppIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankAppIdentityProject.PresentationLayer.Controllers
{
    public class TempController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityOptions _identityOptions;
        public TempController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IdentityOptions identityOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _identityOptions = identityOptions;
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
                var user = await _userManager.FindByEmailAsync(logInViewModel.username);
                if (user.EmailConfirmed.Equals(true))
                {
                    return RedirectToAction("Index", "MyProfile");
                }
            }

            else if (result.IsLockedOut)
            {
                var lockEndTime = await _userManager.GetLockoutEndDateAsync(userName);
                DateTime liveTimeUTC = DateTime.UtcNow;
                ModelState.AddModelError("", $"{userName} adlı hesabınız {(lockEndTime.Value.UtcDateTime - DateTime.UtcNow).Minutes} dəqiqə  {(lockEndTime.Value.UtcDateTime - DateTime.UtcNow).Seconds} saniyə  müddəti ərzində bloka düşdü");
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
                    int maxFailedAccessAttempts = _identityOptions.Lockout.MaxFailedAccessAttempts;
                    var maxFailedCount = _userManager.Options.Lockout.MaxFailedAccessAttempts;
                    ModelState.AddModelError("", $"{maxFailedCount - failedCount} dəfə  səhv etsəz hesabınız ban olacaq keçici olaraq");
                }

            }
            return View();
        }
    }
}
