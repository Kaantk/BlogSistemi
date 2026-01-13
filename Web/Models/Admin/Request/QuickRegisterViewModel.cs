namespace Web.Models.Admin.Request
{
    public class QuickRegisterViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public bool VerifyEmail { get; set; }
    }
}
