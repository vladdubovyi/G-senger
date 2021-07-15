using System.ComponentModel.DataAnnotations;

namespace G_senger.Models
{
    public class Contacts
    {
        [Key]
        public int Id { get; set; }

        public User User1 { get; set; }

        public User User2 { get; set; }
    }
}
