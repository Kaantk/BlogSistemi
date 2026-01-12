using Core.Utilities.Results;
using Entities.Dtos.Auth.Request;
using Entities.Dtos.Auth.Response;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<UserForLoginResponseDto>> LoginAsync(UserForLoginDto dto);
    }
}
