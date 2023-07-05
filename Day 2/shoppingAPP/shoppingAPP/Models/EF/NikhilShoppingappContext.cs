using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace shoppingAPP.Models.EF;

public partial class NikhilShoppingappContext : DbContext
{
    public NikhilShoppingappContext()
    {
    }

    public NikhilShoppingappContext(DbContextOptions<NikhilShoppingappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomersList> CustomersLists { get; set; }

    public virtual DbSet<Productlist> Productlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:shoppinginstance.database.windows.net,1433;Initial Catalog=nikhil_shoppingapp;Persist Security Info=False;User ID=trainer;Password=Password@1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomersList>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__customer__D830D4778E10A9ED");

            entity.ToTable("customersList");

            entity.Property(e => e.CId)
                .ValueGeneratedNever()
                .HasColumnName("cId");
            entity.Property(e => e.CCity)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cCity");
            entity.Property(e => e.CIsActive).HasColumnName("cIsActive");
            entity.Property(e => e.CName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cName");
            entity.Property(e => e.CWalletBalance).HasColumnName("cWalletBalance");
        });

        modelBuilder.Entity<Productlist>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__productl__DD36D562EC236E74");

            entity.ToTable("productlist");

            entity.Property(e => e.PId)
                .ValueGeneratedNever()
                .HasColumnName("pId");
            entity.Property(e => e.PCategory)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pCategory");
            entity.Property(e => e.PIsInStock).HasColumnName("pIsInStock");
            entity.Property(e => e.PName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pName");
            entity.Property(e => e.PPrice).HasColumnName("pPrice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
