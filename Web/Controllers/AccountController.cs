using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Favorites()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MyPosts()
        {
            return View();
        }

    }
}
