namespace Web.Models.Common.User
{
    public class UserForLoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
