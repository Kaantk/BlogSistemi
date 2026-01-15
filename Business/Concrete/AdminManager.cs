using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Admin;
using Entities.Dtos.Admin.Request;
using Entities.Dtos.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IUserDal _userDal;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminManager(IUserDal userDal, UserManager<ApplicationUser> userManager)
        {
            _userDal = userDal;
            _userManager = userManager;
        }

        public async Task<ApiResponse<List<ApplicationUser>>> GetUsersAsync()
        {
            try
            {
                var users = await _userDal.GetAllAsync();

                return new ApiResponse<List<ApplicationUser>>
                {
                    Success = true,
                    Data = users,
                    Message = Messages.UsersListed
                };
            }
            catch
            {
                return new ApiResponse<List<ApplicationUser>>
                {
                    Success = false,
                    Data = null,
                    Message = Messages.UnexpectedError
                };
            }
        }

        public async Task<ApiResponse<ApplicationUser>> QuickRegisterAsync(QuickRegisterDto dto)
        {
            // Giriş verisi doğrulaması
            if (dto == null)
            {
                return new ApiResponse<ApplicationUser>
                {
                    Success = false,
                    Data = null,
                    Message = Messages.ValidationError
                };
            }

            // Email adresi daha önce kullanılmış mı kontrol et
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);

            // Email kayıtlıysa işlem durdurulur
            if (existingUser != null)
            {
                return new ApiResponse<ApplicationUser>
                {
                    Success = false,
                    Data = null,
                    Message = Messages.UserAlreadyExists
                };
            }

            // Yeni kullanıcı nesnesi oluştur
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                EmailConfirmed = true
            };

            // Kullanıcıyı Identity üzerinden kaydet
            var createResult = await _userManager.CreateAsync(user, dto.Password);

            // Kayıt başarısızsa hata sonucu döndür
            if (!createResult.Succeeded)
            {
                return new ApiResponse<ApplicationUser>
                {
                    Success = false,
                    Data = null,
                    Message = Messages.UserCreateFailed
                };
            }

            // Kullanıcıya rol ata
            await _userManager.AddToRoleAsync(user, dto.Role);

            // Başarılı kayıt sonucu döndür
            return new ApiResponse<ApplicationUser>
            {
                Success = true,
                Data = user,
                Message = Messages.UserCreated
            };
        }

    }
}
