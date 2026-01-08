
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models.ViewModels.User;
using Web.Services.Auth.Abstract;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IApiAuthService _apiAuthService;
        private readonly IAuthSessionService _authSessionService;

        public AuthController(IApiAuthService apiAuthService, IAuthSessionService authSessionService)
        {
            _apiAuthService = apiAuthService;
            _authSessionService = authSessionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginViewModel dto)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen form hatalarını düzeltin.";
                return View(dto);
            }

            // API isteği
            var result = await _apiAuthService.LoginAsync(dto);

            if (!result.Success)
            {
                ViewBag.ErrorMessage = result.Message;
                return View(dto);
            }

            // 4JWT → Cookie Auth (tüm detay servis içinde)
            await _authSessionService.SignInAsync(result.Data.AccessToken);

            return RedirectToAction("Index", "Home");
        }
    }
}
