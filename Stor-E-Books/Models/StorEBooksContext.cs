using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Stor_E_Books.Models;

namespace Stor_E_Books.Models;

public partial class StorEBooksContext : DbContext
{
    public StorEBooksContext()
    {
    }

    public StorEBooksContext(DbContextOptions<StorEBooksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__CUSTOMER__B611CB9DA11967BE");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<Stor_E_Books.Models.Items> Items { get; set; } = default!;

public DbSet<Stor_E_Books.Models.Cart> Cart { get; set; } = default!;
}
