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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
