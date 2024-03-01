using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<CartOrder> CartOrders { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Unsuccessfullogin> Unsuccessfullogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LUBNAH\\SQLEXPRESS;Database=Stor-E-Books;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__CART__415B03D8A820B28D");

            entity.ToTable("CART");

            entity.Property(e => e.CartId)
                .ValueGeneratedNever()
                .HasColumnName("cartID");
            entity.Property(e => e.BookId).HasColumnName("bookID");
            entity.Property(e => e.CartPriceTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cartPriceTotal");
            entity.Property(e => e.CartQuantity).HasColumnName("cartQuantity");

            entity.HasOne(d => d.Book).WithMany(p => p.Carts)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__CART__bookID__4316F928");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.CartItemId).HasName("PK__CART_ITE__283983961EBDC801");

            entity.ToTable("CART_ITEM");

            entity.Property(e => e.CartItemId)
                .ValueGeneratedNever()
                .HasColumnName("cartItemID");
            entity.Property(e => e.BookId).HasColumnName("bookID");
            entity.Property(e => e.CartId).HasColumnName("cartID");

            entity.HasOne(d => d.Book).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__CART_ITEM__bookI__4AB81AF0");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__CART_ITEM__cartI__49C3F6B7");
        });

        modelBuilder.Entity<CartOrder>(entity =>
        {
            entity.HasKey(e => e.CartOrderId).HasName("PK__CART_ORD__71715B447BA57342");

            entity.ToTable("CART_ORDER");

            entity.Property(e => e.CartOrderId)
                .ValueGeneratedNever()
                .HasColumnName("cartOrderID");
            entity.Property(e => e.CartId).HasColumnName("cartID");
            entity.Property(e => e.OrderId).HasColumnName("orderID");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartOrders)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__CART_ORDE__cartI__45F365D3");

            entity.HasOne(d => d.Order).WithMany(p => p.CartOrders)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__CART_ORDE__order__46E78A0C");
        });

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

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__ITEMS__8BE5A12D998F3717");

            entity.ToTable("ITEMS");

            entity.Property(e => e.BookId).HasColumnName("bookID");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("author");
            entity.Property(e => e.BookName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("bookName");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("genre");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__ORDERS__0809337DD6164265");

            entity.ToTable("ORDERS");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("orderID");
            entity.Property(e => e.BookId).HasColumnName("bookID");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.OrderPriceTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("orderPriceTotal");
            entity.Property(e => e.OrderQuantity).HasColumnName("orderQuantity");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("paymentStatus");

            entity.HasOne(d => d.Book).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__ORDERS__bookID__3C69FB99");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__ORDERS__customer__3D5E1FD2");
        });

        modelBuilder.Entity<Unsuccessfullogin>(entity =>
        {
            entity.HasKey(e => e.UnsuccessfulLoginId).HasName("PK__UNSUCCES__4D8FA7099B521697");

            entity.ToTable("UNSUCCESSFULLOGIN");

            entity.Property(e => e.UnsuccessfulLoginId)
                .ValueGeneratedNever()
                .HasColumnName("unsuccessfulLoginID");
            entity.Property(e => e.AttemptedDateTime).HasColumnName("attemptedDateTime");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Unsuccessfullogins)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__UNSUCCESS__custo__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
