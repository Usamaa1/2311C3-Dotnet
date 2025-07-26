using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using addToCart.Models;

namespace addToCart.Data;

public partial class CartDbContext : DbContext
{
    public CartDbContext()
    {
    }

    public CartDbContext(DbContextOptions<CartDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07B01EA4B3");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasColumnName("categoryName");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC0730B9413F");

            entity.ToTable("Product");

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.ProdDesc).HasColumnName("prodDesc");
            entity.Property(e => e.ProdImage)
                .HasDefaultValue("No Image")
                .HasColumnName("prodImage");
            entity.Property(e => e.ProdName).HasColumnName("prodName");
            entity.Property(e => e.ProdPrice).HasColumnName("prodPrice");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__categor__3A81B327");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC07D048D441");

            entity.ToTable("Cart");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Cart__UserId__4CA06362");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC077CFCBF0B");

            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC070155A807");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderItem__Order__534D60F1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC079111F077");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105340ECDB119").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
