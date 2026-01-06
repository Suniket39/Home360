using Home360.Domain.Entities.UserManagement;

namespace Home360.Domain.Entities
{
    public class User : CommonEntity
    {
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public string? MobileNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int RoleId { get; set; }
        public RoleMaster? Role { get; set; }
    }
}
