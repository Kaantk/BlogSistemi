using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models.ViewModels.Home;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Kullanıcın rolü Admin ise direkt admin panele yönlendir
            if (User.IsInRole("Admin"))
                return RedirectToAction("Index", "Admin");

            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            // Burada model doğrulama ve e-posta gönderme işlemleri yapılabilir
            return View();
        }

    }
}
