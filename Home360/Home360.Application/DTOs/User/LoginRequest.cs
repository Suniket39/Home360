using System.ComponentModel.DataAnnotations;

namespace Home360.Application.DTOs
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "User Name is required.")]
        [MinLength(3, ErrorMessage = "User Name should be aleast 3 characters.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage ="Password should be aleast 8 characters.")]
        public string Password { get; set; } = string.Empty;
    }
}
