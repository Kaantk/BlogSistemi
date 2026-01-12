namespace Web.Models.Admin.Request
{
    public class UsersViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate {  get; set; }
    }
}
