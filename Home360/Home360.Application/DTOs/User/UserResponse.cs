namespace Home360.Application.DTOs
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? MobileNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string[] Roles { get; set; } = Array.Empty<string>();
    }
}
