namespace Home360.Application.DTOs
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? MobileNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string[] Roles { get; set; } = Array.Empty<string>();
    }
}
