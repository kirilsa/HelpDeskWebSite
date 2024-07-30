namespace HelpDeskWebSite.Models
{
    public class Email
    {
        public int EmailId { get; set; }
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentDate { get; set; } = DateTime.UtcNow;
        public bool IsIncoming { get; set; }
        public int ConversationId { get; set; }

        // Navigation properties
        public User Sender { get; set; }
        public User Recipient { get; set; }
        public Conversation Conversation { get; set; }

    }
}
