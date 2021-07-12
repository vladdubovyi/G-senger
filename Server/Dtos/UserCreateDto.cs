using System.ComponentModel.DataAnnotations;

namespace G_senger.Dtos
{
    public class UserCreateDto
    {
        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [MaxLength(256)]
        public string FirstName { get; set; }

        [MaxLength(256)]
        public string LastName { get; set; }
    }
}
