using System;
using System.ComponentModel.DataAnnotations;

namespace DesktopApp.Dtos
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string Password { get; set; }

        [MaxLength(256)]
        public string FirstName { get; set; }

        [MaxLength(256)]
        public string LastName { get; set; }

        public override string ToString()
        {
            string res = String.Empty;
            
            if (!String.IsNullOrEmpty(FirstName))
                res += FirstName + " ";
            if (!String.IsNullOrEmpty(LastName))
                res += LastName + " ";
            if (!String.IsNullOrEmpty(Email) && String.IsNullOrEmpty(res))
                res += Email + " ";

            return res;
        }
    }
}
