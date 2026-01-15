using Business.Abstract;
using Entities.Dtos.Admin.Request;
using Entities.Dtos.Common;
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

            // İşlem başarısızsa olduğu gibi dön
            if (!result.Success)
                return BadRequest(result);

            // ApplicationUser -> UsersViewModel map
            var usersViewModel = result.Data.Select(u => new UsersViewModel
            {
                Id = u.Id,
                UserName = u.UserName,
                Email = u.Email,
                Role = u.NormalizedUserName, // (ileride Role ayrı alınmalı)
                Status = u.Status,
                IsDeleted = u.IsDeleted,
                CreatedDate = u.CreatedDate
            }).ToList();

            // Aynı response yapısını KORU
            return Ok(new ApiResponse<List<UsersViewModel>>
            {
                Success = true,
                Data = usersViewModel,
                Message = result.Message
            });
        }

        [HttpPost("quickregister")]
        public async Task<IActionResult> QuickRegister(QuickRegisterDto dto)
        {
            var result = await _adminService.QuickRegisterAsync(dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}

