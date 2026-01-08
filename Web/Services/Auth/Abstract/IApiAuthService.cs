using Web.Models.Common;
using Web.Models.ViewModels.User;

namespace Web.Services.Auth.Abstract
{
    public interface IApiAuthService
    {
        Task<ApiResponse<UserForLoginResponseViewModel>> LoginAsync(UserForLoginViewModel dto);
    }
}
