using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Dtos.Admin;
using Entities.Dtos.Common;
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

        public AdminManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<ApiResponse<List<ApplicationUser>>> GetUsersAsync()
        {
            try
            {
                var userList = await _userDal.GetAllAsync();
                return new ApiResponse<List<ApplicationUser>>
                {
                    Success = true,
                    Data = userList,
                    Message = "Kullanıcılar başarıyla getirildi."
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<ApplicationUser>>
                {
                    Success = false,
                    Data = null,
                    Message = $"Kullanıcılar getirilirken hata oluştu: {ex.Message}"
                };
            }
        }
    }
}
