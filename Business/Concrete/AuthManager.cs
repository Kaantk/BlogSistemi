using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Security.Jwt;
using Entities.Dtos.Auth.Request;
using Entities.Dtos.Auth.Response;
using Entities.Dtos.Common;
using Microsoft.AspNetCore.Identity;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(UserManager<ApplicationUser> userManager, ITokenHelper tokenHelper)
        {
            _userManager = userManager;
            _tokenHelper = tokenHelper;
        }

        public async Task<ApiResponse<UserForLoginResponseDto>> LoginAsync(UserForLoginDto dto)
        {
            // Giriş verisi doğrulaması
            if (dto == null)
            {
                return new ApiResponse<UserForLoginResponseDto>
                {
                    Success = false,
                    Data = null,
                    Message = Messages.ValidationError
                };
            }

            // Kullanıcı email adresine göre bulunur
            var user = await _userManager.FindByEmailAsync(dto.Email);

            // Kullanıcı bulunamazsa hata döndürülür
            if (user == null)
            {
                return new ApiResponse<UserForLoginResponseDto>
                {
                    Success = false,
                    Data = null,
                    Message = Messages.UserNotFound
                };
            }

            // Kullanıcı şifresi kontrol edilir
            var passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordValid)
            {
                return new ApiResponse<UserForLoginResponseDto>
                {
                    Success = false,
                    Data = null,
                    Message = Messages.PasswordError
                };
            }

            // Kullanıcıya ait roller alınır
            var roles = await _userManager.GetRolesAsync(user);

            // JWT access token oluşturulur
            var accessToken = _tokenHelper.CreateToken(user, roles);

            // Başarılı giriş sonucu döndürülür
            return new ApiResponse<UserForLoginResponseDto>
            {
                Success = true,
                Data = new UserForLoginResponseDto
                {
                    AccessToken = accessToken.Token,
                    Expiration = accessToken.Expiration
                },
                Message = Messages.SuccessfulLogin
            };
        }
    }
}
