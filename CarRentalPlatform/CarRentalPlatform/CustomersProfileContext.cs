using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarRentalPlatform;

public partial class CustomersProfileContext : DbContext
{
    public CustomersProfileContext()
    {
    }

    public CustomersProfileContext(DbContextOptions<CustomersProfileContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("\nData Source=(localdb)\\ProjectModels;\nInitial Catalog=CustomersProfile;\nIntegrated Security=True;\nConnect Timeout=30;\nEncrypt=True;\nTrust Server Certificate=False;\nApplication Intent=ReadWrite;\nMulti Subnet Failover=False;\nCommand Timeout=30\n");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0778A711DE");

            entity.ToTable("Customer");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
