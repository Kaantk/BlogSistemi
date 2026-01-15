using Core.Utilities.Results;
using Entities.Dtos.Auth.Request;
using Entities.Dtos.Auth.Response;
using Entities.Dtos.Common;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<ApiResponse<UserForLoginResponseDto>> LoginAsync(UserForLoginDto dto);
    }
}
