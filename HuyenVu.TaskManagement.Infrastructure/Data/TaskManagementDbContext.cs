using System.Collections.Generic;
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

        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskHistory> TaskHistories { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(ConfigureUserTable);
            modelBuilder.Entity<Task>(ConfigureTaskTable);
            modelBuilder.Entity<TaskHistory>(ConfigureTaskHistory);

            modelBuilder.Entity<Role>(ConfigureRoleTable);
            
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>("UsersRoles",
                    u => u.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    r => r.HasOne<User>().WithMany().HasForeignKey("UserId")
                );
        }

        private void ConfigureRoleTable(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).HasMaxLength(50);
        }

        private void ConfigureUserTable(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.Password).HasMaxLength(10).IsRequired();
            builder.Property(u => u.FullName).HasMaxLength(50);
            builder.Property(u => u.MobileNo).HasMaxLength(50);
        }

        private void ConfigureTaskTable(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(500);
            builder.Property(t => t.DueDate).HasColumnType("Date");
            builder.Property(t => t.Remarks).HasMaxLength(500);
        }

        private void ConfigureTaskHistory(EntityTypeBuilder<TaskHistory> builder)
        {
            builder.ToTable("Task_History");
            builder.HasKey(t => t.TaskId);
            builder.Property(t => t.Title).HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(500);
            builder.Property(t => t.Remarks).HasMaxLength(500);
        }
    }
}