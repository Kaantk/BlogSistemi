using Web.Models.Common;
using Web.Models.Common.User;

namespace Web.Services.Auth.Abstract
{
    public interface IApiAuthService
    {
        Task<ApiResponse<UserForLoginResponseViewModel>> LoginAsync(UserForLoginViewModel dto);
    }
}
