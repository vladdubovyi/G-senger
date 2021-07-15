using System.ComponentModel.DataAnnotations;

namespace G_senger.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public User Sender { get; set; }

        public User Recipient { get; set; }

        public string Text { get; set; }
    }
}
