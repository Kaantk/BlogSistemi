using Core.Utilities.Results;
using Entities.Dtos.User;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<UserForLoginResponseDto>> LoginAsync(UserForLoginDto dto);
    }
}
