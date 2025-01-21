using System;
using System.Collections.Generic;
using AppleStore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppleStore.Context;

public partial class DbAppleTechnicStoreContext : DbContext
{
    public DbAppleTechnicStoreContext()
    {
    }

    public DbAppleTechnicStoreContext(DbContextOptions<DbAppleTechnicStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppleShop> AppleShops { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QR6M5JQ;Database=dbAppleTechnicStore;Trusted_Connection=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppleShop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AppleTechnicShop");

            entity.ToTable("AppleShop");

            entity.Property(e => e.Brands).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductName).HasMaxLength(100);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("Document");

            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.HasComments).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.PasswordHash).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
