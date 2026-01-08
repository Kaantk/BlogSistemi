namespace Web.Models.ViewModels.User
{
    public class UserForLoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
