using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WinFormEF_App.Models
{
    public partial class NorthWindContext : DbContext
    {
        public NorthWindContext()
        {
        }

        public NorthWindContext(DbContextOptions<NorthWindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Northwind;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<ProductDetailsDtoKeyLess>().HasNoKey().ToView("anyname"); // Not mapped to a view or table u can put a view any name hi will create it if he dont find it

            modelBuilder.Entity<TopCustIdKeyLess>().HasNoKey();
            //modelBuilder.Entity<TopCustIdKeyLess>(entity =>
            //{
            //    entity.HasNoKey();  // Mark as keyless
            //    //entity.ToTable("Customers");  // Optional: map to a table (can omit if using only stored proc)
            //});

            modelBuilder.UseCollation("Arabic_CI_AS");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ReorderLevel).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitPrice).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitsInStock).HasDefaultValueSql("((0))");

                entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_Products_Suppliers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
