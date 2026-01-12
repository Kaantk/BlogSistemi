using Business.Abstract;
using Entities.Dtos.Admin.UserManagement;
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

        public Task<ApiResponse<UserManagementListDto>> ListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
