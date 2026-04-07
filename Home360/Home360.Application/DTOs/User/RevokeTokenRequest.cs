using System.ComponentModel.DataAnnotations;

namespace Home360.Application.DTOs
{
    public class RevokeTokenRequest
    {
        [Required(ErrorMessage ="Refresh Token is required")]
        public string Token { get; set; }
    }
}
