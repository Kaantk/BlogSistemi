namespace Web.Models.Auth.Response
{
    public class UserForLoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
