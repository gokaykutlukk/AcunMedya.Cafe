using Microsoft.AspNetCore.Mvc;
using AcunMedya.Cafe.Entities;
using AcunMedya.Cafe.Context;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace AcunMedya.Cafe.Controllers
{
    public class LoginController : Controller
    {
        private readonly CafeContext _context;

        public LoginController(CafeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doldurun.";
                return View();
            }

            var userInfo = _context.Users
                .FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);

            if (userInfo != null)
            {
                // Giriş başarılı
                HttpContext.Session.SetString("username", userInfo.UserName);
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }

            // Giriş başarısızsa:
            ViewBag.ErrorMessage = "Hatalı kullanıcı adı veya şifre";
            return View();

        }
    }
}
