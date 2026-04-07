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
        public string? VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue;
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }

        public RoleMaster? Role { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

        public bool OwnsToken(string token) => RefreshTokens?.Any(rt => rt.Token == token) == true;
    }
}
