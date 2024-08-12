using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiCore.Data;

public partial class FnfTrainingContext : DbContext
{
    public FnfTrainingContext()
    {
    }

    public FnfTrainingContext(DbContextOptions<FnfTrainingContext> options)
        : base(options)
    {

    }

    public virtual DbSet<DeptTable> DeptTables { get; set; }

    public virtual DbSet<EmpTable> EmpTables { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      //  => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=FnfTraining; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeptTable>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__DeptTabl__014881AE7C51AECD");

            entity.ToTable("DeptTable");

            entity.Property(e => e.Deptname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmpTable>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__EmpTable__AFB3EC0D901BE6FE");

            entity.ToTable("EmpTable");

            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.EmpAddress)
                .HasMaxLength(200)
                .HasColumnName("empAddress");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .HasColumnName("empName");
            entity.Property(e => e.EmpSalary)
                .HasColumnType("money")
                .HasColumnName("empSalary");

            entity.HasOne(d => d.Dept).WithMany(p => p.EmpTables)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__EmpTable__DeptId__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
