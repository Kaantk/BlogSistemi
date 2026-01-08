

using Business.Abstract;
using Entities.Dtos.Common;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto dto)
        {
            // Gelen veri kontrolü ve geri dönüş değeri
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
            {
                return Ok(new ApiResponse<UserForLoginResponseDto>
                {
                    Success = false,
                    Data = null,
                    Message = "Email veya şifre boş olamaz."
                });
            }

            // Kullanıcı girişi için business manager çağrımı
            var result = await _authService.LoginAsync(dto);

            // Managerdan gelen veriyi response ile taşı
            var response = new ApiResponse<UserForLoginResponseDto>
            {
                Success = result.Success,
                Data = result.Data,
                Message = result.Message
            };

            // Response geri döndür
            return Ok(response);
        }
    }
}
