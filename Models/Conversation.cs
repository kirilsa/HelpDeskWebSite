namespace HelpDeskWebSite.Models
{
    public class Conversation
    {
        public int ConversationId { get; set; }
        public string Subject { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public int StartedByUserId { get; set; }

        // Navigation properties
        public User StartedByUser { get; set; }
        public ICollection<Email> Emails { get; set; }
    }
}
