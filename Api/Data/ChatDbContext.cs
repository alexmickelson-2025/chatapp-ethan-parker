namespace Api.Data;

using Logic;
using Microsoft.EntityFrameworkCore;

public class ChatDbContext : DbContext
{
    public DbSet<Message> Messages { get; set; }

    public ChatDbContext(DbContextOptions<ChatDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>(entity =>
        {
            entity.ToTable("message", "postgres");

            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.TimePosted).HasColumnName("time_posted");
            entity.Property(e => e.Username).HasColumnName("username");
            entity.Property(e => e.LamportNumber).HasColumnName("lamport_number");
            entity.Property(e => e.ProcessId).HasColumnName("process_id");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.ImageApiId).HasColumnName("image_api_id");

            entity.HasKey(e => e.Id);
        });

        base.OnModelCreating(modelBuilder);
    }
}
