using Core.Entities;
using Core.Entities.Concrete;
using Entities.Dtos.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Models.Admin.Request;
using Web.Models.Auth.Response;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        #region Get İşlemleri

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("admin/getusers");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "API ile bağlantı kurulamadı.";
                return View(new List<UsersViewModel>());
            }

            var result = await response.Content.ReadFromJsonAsync<ApiResponse<List<UsersViewModel>>>();

            if (result == null || !result.Success)
            {
                ViewBag.ErrorMessage = result?.Message ?? "Kullanıcılar yüklenemedi.";
                return View(new List<UsersViewModel>());
            }

            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Roles()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ApprovelPost()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Categories()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ApprovelComment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult WebsiteSettings()
        {
            return View();
        }

        #endregion

        #region Post İşlemleri

        [HttpPost]
        public async Task<IActionResult> QuickRegister(QuickRegisterViewModel dto)
        {
            // Validation
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Lütfen form hatalarını düzeltin.";
                return View(dto);
            }

            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.PostAsJsonAsync("admin/quickregister", dto);

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.ErrorMessage = "API ile bağlantı kurulamadı.";
                return View(dto);
            }

            var result = await response.Content.ReadFromJsonAsync<ApiResponse<ApplicationUser>>();

            if (result == null || !result.Success)
            {
                ViewBag.ErrorMessage = result?.Message ?? "Kullanıcı eklenirken bir hata oluştu.";
                return View(dto);
            }

            return RedirectToAction("Users");
        }

        #endregion

    }
}
