using Entities.Dtos.Admin.UserManagement;
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
        Task<ApiResponse<UserManagementListDto>> ListAsync();
    }
}
