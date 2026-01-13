namespace Web.Models.Admin.Request
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public bool? IsDeleted { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
