using Core.Entities;
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

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var response = await client.GetAsync("admin/users"); 

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

        public IActionResult Index()
        {
            return View();
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

    }
}
