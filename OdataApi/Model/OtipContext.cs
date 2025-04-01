using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OdataApi.Model;

public partial class OtipContext : DbContext
{
    public OtipContext()
    {
    }

    public OtipContext(DbContextOptions<OtipContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:otipdbconn");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Customer__3213E83F64EE6B38");

            entity.ToTable("Customer");

            entity.Property(e => e.id).ValueGeneratedNever();
            entity.Property(e => e.name).HasMaxLength(100);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__Order__3213E83F4E2CEF53");

            entity.ToTable("Order");

            entity.Property(e => e.id).ValueGeneratedNever();

            entity.HasOne(d => d.customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.customer_id)
                .HasConstraintName("FK__Order__customer___5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
