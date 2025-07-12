using System;
using System.Collections.Generic;
using APIProject.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Data;

public partial class Db2311C3Context : DbContext
{
    public Db2311C3Context()
    {
    }

    public Db2311C3Context(DbContextOptions<Db2311C3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Student> Students { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07055526A1");

            entity.Property(e => e.ProdDesc).HasColumnName("prodDesc");
            entity.Property(e => e.ProdName).HasColumnName("prodName");
            entity.Property(e => e.ProdPrice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("prodPrice");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0779BB8EDD");

            entity.ToTable("Student");

            entity.Property(e => e.StudentAge).HasColumnName("studentAge");
            entity.Property(e => e.StudentClass)
                .HasMaxLength(50)
                .HasColumnName("studentClass");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .HasColumnName("studentName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
