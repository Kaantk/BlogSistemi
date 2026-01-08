namespace Web.Services.Auth.Abstract
{
    public interface IAuthSessionService
    {
        Task SignInAsync(string accessToken);
        Task SignOutAsync();
    }
}
