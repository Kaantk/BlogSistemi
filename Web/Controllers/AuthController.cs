using Entities.Dtos.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Web.Models.Auth.Request;
using Web.Models.Auth.Response;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #region HttpGet İşlemleri

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        #endregion

        #region HttpPost İşlemleri

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
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.PostAsJsonAsync("auth/login", dto);

            // API'den dönen veriye göre cevap döndür
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "API ile bağlantı kurulamadı.";
                return View(dto);
            }

            var result = await response.Content.ReadFromJsonAsync<ApiResponse<UserForLoginResponseViewModel>>();

            if (result == null || !result.Success)
            {
                ViewBag.ErrorMessage = result?.Message ?? "Giriş başarısız.";
                return View(dto);
            }

            // JWT → Cookie Auth
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(result.Data.AccessToken);
            var claims = jwtToken.Claims.ToList();

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme,
                ClaimTypes.Name,
                ClaimTypes.Role
            );

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = jwtToken.ValidTo
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                authProperties
            );

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserForRegisterViewModel dto)
        {
            // Kullanıcı kayıt işlemleri yapılacak
            return View();
        }
        #endregion
    }
}