using Microsoft.EntityFrameworkCore;
using TarasMessenger.Core.Models;
using TarasMessenger.Core.Models.Messages;

namespace TarasMessanger.Storage;

public class DataContext : DbContext
{
    public DbSet<MessageBase> MessageBases { get; set; }
    public DbSet<Attachment> Attachments { get; set; }

    public DbSet<User> Users { get; set; }
    public DbSet<Chat> Chats { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<MessageBase>()
            .HasOne(m => m.User)
            .WithMany() 
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MessageBase>()
            .HasOne(m => m.Chat)
            .WithMany(c => c.Messages) 
            .HasForeignKey(m => m.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MessageBase>()
            .HasMany(m => m.Attachments)
            .WithOne(a => a.Message)
            .HasForeignKey(a => a.MessageId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MessageBase>()
            .HasIndex(m => m.ChatId);

        modelBuilder.Entity<MessageBase>()
            .HasIndex(m => m.SendAt);

        modelBuilder.Entity<Attachment>()
            .Property(a => a.FileName)
            .IsRequired()
            .HasMaxLength(255);

        modelBuilder.Entity<Attachment>()
            .Property(a => a.FilePath)
            .IsRequired();

        modelBuilder.Entity<Attachment>()
            .Property(a => a.ContentType)
            .HasMaxLength(100);
    }
}