using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleWebApi.Data;

public partial class FnfTrainingContext : DbContext
{
    public FnfTrainingContext()
    {
    }

    public FnfTrainingContext(DbContextOptions<FnfTrainingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StockTable> StockTables { get; set; }

  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database=FnfTraining; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        modelBuilder.Entity<StockTable>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__StockTab__CBAD8763F8010964");

            entity.ToTable("StockTable");

            entity.Property(e => e.StockId).HasColumnName("stockId");
            entity.Property(e => e.StockDescription)
                .IsUnicode(false)
                .HasColumnName("stockDescription");
            entity.Property(e => e.StockName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("stockName");
            entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
