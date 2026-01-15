using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos.Admin;
using Entities.Dtos.Admin.Request;
using Entities.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService 
    {
        Task<ApiResponse<List<ApplicationUser>>> GetUsersAsync(); // Kullanıcı listesini getirir
        Task<ApiResponse<ApplicationUser>> QuickRegisterAsync(QuickRegisterDto dto); // Admin panel hızlı kullanıcı kaydı oluştur
    }
}
