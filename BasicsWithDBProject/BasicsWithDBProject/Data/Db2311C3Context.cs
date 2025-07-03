using System;
using System.Collections.Generic;
using BasicsWithDBProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicsWithDBProject.Data;

public partial class Db2311C3Context : DbContext
{
    public Db2311C3Context()
    {
    }
    public Db2311C3Context(DbContextOptions<Db2311C3Context> options)
        : base(options)
    {
    }
    public virtual DbSet<Student> Students { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
