

using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Dtos.User;
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

        public async Task<IDataResult<UserForLoginResponseDto>> LoginAsync(UserForLoginDto dto)
        {
            // Kullanıcı varlığını kontrol et
            var user = await _userManager.FindByEmailAsync(dto.Email);

            // Kullanıcı yoksa hata mesajı döndür
            if (user == null)
                return new ErrorDataResult<UserForLoginResponseDto>(Messages.UserNotFound);

            // Kullanıcı şifresini kontrol et
            if (!await _userManager.CheckPasswordAsync(user, dto.Password))
                return new ErrorDataResult<UserForLoginResponseDto>(Messages.PasswordError);

            // Kullanıcı rollerini al
            var roles = await _userManager.GetRolesAsync(user);

            // Access Token (JWT)
            var accessToken = _tokenHelper.CreateToken(user, roles);

            return new SuccessDataResult<UserForLoginResponseDto>(new UserForLoginResponseDto
            {
                AccessToken = accessToken.Token,
                Expiration = accessToken.Expiration
            });
        }
    }
}
