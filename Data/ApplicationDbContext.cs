using HelpDeskWebSite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskWebSite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //public DbSet<EmailMessage> EmailMessages { get; set; }
        public DbSet<User> Users {  get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)   //define tables relationships 
        {
            base.OnModelCreating(modelBuilder);

            // Configure Email-Sender relationship
            modelBuilder.Entity<Email>() 
                .HasOne(e => e.Sender)
                .WithMany(u => u.SentEmails)
                .HasForeignKey(e => e.SenderId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Configure Email-Recipient relationship
            modelBuilder.Entity<Email>()
                .HasOne(e => e.Recipient)
                .WithMany(u => u.ReceivedEmails)
                .HasForeignKey(e => e.RecipientId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Configure Email-Conversation relationship
            modelBuilder.Entity<Email>()
                .HasOne(e => e.Conversation)
                .WithMany(c => c.Emails)
                .HasForeignKey(e => e.ConversationId);

            // Configure Conversation-StartedBy relationship
            modelBuilder.Entity<Conversation>()
                .HasOne(c => c.StartedByUser)
                .WithMany()
                .HasForeignKey(c => c.StartedByUserId);
        }
    }
}
