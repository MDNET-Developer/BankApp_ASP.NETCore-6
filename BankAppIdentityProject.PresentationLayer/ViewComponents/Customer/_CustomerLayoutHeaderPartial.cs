using Microsoft.AspNetCore.Mvc;

namespace BankAppIdentityProject.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutHeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
                 return View();
        }
    }
}
