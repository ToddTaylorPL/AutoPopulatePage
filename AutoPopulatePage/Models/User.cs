namespace AutoPopulatePage.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Intials { get; set; }
        public bool IsActive { get; set; }
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public string Image { get; set; }
    }

}
