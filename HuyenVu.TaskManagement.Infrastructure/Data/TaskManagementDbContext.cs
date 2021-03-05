using HuyenVu.TaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HuyenVu.TaskManagement.Infrastructure.Data
{
    public class TaskManagementDbContext : DbContext
    {
        public TaskManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(ConfigureUserTable);
        }

        private void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.Password).HasMaxLength(10).IsRequired();
            builder.Property(u => u.FullName).HasMaxLength(50);
            builder.Property(u => u.MobileNo).HasMaxLength(50);
        }
    }
}