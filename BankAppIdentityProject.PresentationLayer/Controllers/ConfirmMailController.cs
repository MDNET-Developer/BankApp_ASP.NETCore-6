using BankAppIdentityProject.EntityLayer.Concrete;
using BankAppIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankAppIdentityProject.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{
	    private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index()
		{
            var mailvalue = TempData["Mail"];
            ViewBag.Mailvalue = mailvalue;
            return View();
		}
		[HttpPost]
        public async Task<IActionResult> Index(ConfirmViewModel confirmViewModel)
        {
            var user = await _userManager.FindByEmailAsync(confirmViewModel.UserMail);
            if (user.ConfirmCode.Equals(confirmViewModel.ConfirmCode))
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "LogIn");
            }
            else
            {
                ViewBag.Message = "Xeta";
                return View(confirmViewModel);
            }
           
        }
    }
}
