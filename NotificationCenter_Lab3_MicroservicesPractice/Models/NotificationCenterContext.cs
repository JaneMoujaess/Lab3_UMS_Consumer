using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NotificationCenter_Lab3_MicroservicesPractice.Models;

public partial class NotificationCenterContext : DbContext
{
    public NotificationCenterContext()
    {
    }

    public NotificationCenterContext(DbContextOptions<NotificationCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Notification> Notifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=NotificationCenter;Username=postgres;Password=inMind2023@#$");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Notifications_pkey");

            entity.Property(e => e.CourseId).ValueGeneratedOnAdd();
            entity.Property(e => e.StudentId).ValueGeneratedOnAdd();
            entity.Property(e => e.TeacherId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
