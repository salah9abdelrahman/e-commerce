namespace commerce.Core.Models
{
    public class UserRole : RowInformation
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

    }
}