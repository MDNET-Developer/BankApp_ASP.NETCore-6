using BankAppIdentityProject.DtoLayer.Dtos.AppUserDtos;
using BankAppIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using MimeKit;
using MailKit.Net.Smtp;

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
                var randomNumber = random.Next(100000, 1000000);

				AppUser appUser = new()
                {
                    Name = registerDto.Name,
                    Surname = registerDto.SurName,
                    Email = registerDto.Email,
                    UserName = registerDto.UserName,
                    ConfirmCode = randomNumber

				};
               var result=  await _userManager.CreateAsync(appUser,password:registerDto.Password);
                if(result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("BankApp Admin", "murad.net.developer@gmail.com");
                    MailboxAddress mailboxAddressTo  = new MailboxAddress("User",appUser.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);
                    var bodyBuilder =  new BodyBuilder();
                    
					string htmlString = $@"<html>
<head>
    <meta charset='UTF-8'>
    <title>Email Design</title>
</head>
<body style='font-family: Arial, sans-serif;'>
    <table width='100%' cellspacing='0' cellpadding='0' style='background-color: #f2f2f2;'>
        <tr>
            <td align='center' style='padding: 20px;'>
                <table width='600' cellspacing='0' cellpadding='0' style='background-color': #ffffff; border-radius: 4px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);'>
                    <tr>
                        <td align='center' style='padding: 20px;'>
                            <h1 style='font-size: 24px; color: #333333; margin-bottom: 20px;'>BankApp doğrulama şifrəsi</h1>
                            <p style='font-size: 16px; color: #666666; margin-bottom: 10px;'>Hörmətli {appUser.Name} {appUser.Surname} sizin qeydiyyatınız üçün son bir addım qalıb.</p>
                            <p style='font-size: 16px; color: #666666; margin-bottom: 10px;'>Zəhmət olmasa təqdim olunmuş doğrulama kodunu daxil edin: <strong>{randomNumber}</strong></p>
                            <p style='font-size: 16px; color: #666666; margin-bottom: 10px;'>Hər hansı bir problem yaranarsa <a href='mailto:murad.aliyev.net@gmail.com' style='color: #007BFF; text-decoration: none;'>e-poçtuna yazın</a>.</p>
                            <p style='font-size: 16px; color: #666666;'>Təşəkkürlər !</p>
                        </td>
                    </tr>
                    <tr>
                        <td align='center' style='padding: 20px; background-color: #f2f2f2; color: #666666; font-size: 14px;'>
                            &copy; 2023 Murad Aliyev. Backend Developer.
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>";
					bodyBuilder.HtmlBody = htmlString;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "BankApp elektron poçt doğrulama kodu";

                    SmtpClient client = new SmtpClient();
				    client.Connect("smtp.gmail.com", 587,false);
					client.Authenticate("murad.net.developer@gmail.com", "jgepmxtbcbdygunj");
					// Send the email
					client.Send(mimeMessage);
					client.Disconnect(true);
                    return RedirectToAction("Index", "ConfirmMail");
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
