using System.ComponentModel.DataAnnotations;

namespace Home360.Application.DTOs
{
    public class UserRquest
    {
        public int UserId { get; set; }  

        [Required(ErrorMessage = "User Name is required!")]
        [MinLength(3)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "First Name is required!")]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [MinLength(5)]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(3)]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required!")]
        [MinLength(3)]
        public required string ConfirmPassword { get; set; }

        [MinLength(3)]
        public string? Email { get; set; }

        [MinLength(3)]
        public string? MobileNumber { get; set; }

    }
}
