using Business.Abstract;
using Core.Entities;
using Core.Entities.Concrete;
using Entities.Dtos.Auth.Response;
using Entities.Dtos.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Admin.Request;

namespace API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _adminService.GetUsersAsync();

            if (!result.Success)
            {
                return Ok(new ApiResponse<List<UsersViewModel>>
                {
                    Success = false,
                    Data = null,
                    Message = result.Message
                });
            }

            // ApplicationUser'ı UsersViewModel'e çevir
            var usersViewModel = result.Data.Select(u => new UsersViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Role = u.NormalizedUserName,
                Status = u.Status,
                IsDeleted = u.IsDeleted,
                CreatedDate = u.CreatedDate,
            }).ToList();

            return Ok(new ApiResponse<List<UsersViewModel>>
            {
                Success = true,
                Data = usersViewModel,
                Message = "Kullanıcılar başarıyla getirildi."
            });
        }
    }
}
