using System.ComponentModel.DataAnnotations;

namespace GameAPI.Models.Creators
{
    public class UserLoginDTO
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}
