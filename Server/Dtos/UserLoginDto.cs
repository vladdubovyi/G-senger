using System.ComponentModel.DataAnnotations;

namespace G_senger.Dtos
{
    public class UserLoginDto
    {
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }
    }
}
