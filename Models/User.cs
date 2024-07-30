using Microsoft.AspNetCore.Identity;

namespace HelpDeskWebSite.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Email> SentEmails { get; set; }
        public ICollection<Email> ReceivedEmails { get; set; }
    }
}
