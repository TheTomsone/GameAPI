using System.ComponentModel.DataAnnotations;

namespace GameAPI.Models.Creators
{
    public class UserRegisterDTO
    {
        [Required]
        public required string Username { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$")]
        public required string Password { get; set; }
    }
}
