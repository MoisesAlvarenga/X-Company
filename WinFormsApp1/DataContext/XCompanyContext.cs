using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using XCompany.Data.Entities;

namespace XCompany.DataContext;

public partial class XCompanyContext : DbContext
{
    public XCompanyContext()
    {
    }

    public XCompanyContext(DbContextOptions<XCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Saleitem> Saleitems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=X_Company;Username=X;Password=x_company;Pooling=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customers_pkey");

            entity.ToTable("customers");

            entity.HasIndex(e => e.Email, "email_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");
            //entity.Ignore(e => e.);

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(12, 2)
                .HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sales_pkey");

            entity.ToTable("sales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("createdat")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")  // Valor padrão no banco de dados
                .ValueGeneratedOnAdd(); ;
            entity.Property(e => e.Saledate)
                .HasColumnType("timestamp")
                .HasColumnName("saledate");

            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Sales)
                .HasForeignKey(d => d.Customerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sales_customers");

            entity.HasMany(e => e.Saleitems)
            .WithOne(e => e.Sale)
            .HasForeignKey(e => e.Saleid)
            .OnDelete(DeleteBehavior.Cascade) // Dependendo do comportamento desejado
            .HasConstraintName("fk_saleitems_sales");

            entity.HasOne(d => d.Customer).WithMany(p => p.Sales)
                .HasForeignKey(d => d.Customerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sale_customers");

            entity.Navigation(e => e.Saleitems)
            .UsePropertyAccessMode(PropertyAccessMode.Field) // Modo de acesso às propriedades
            .AutoInclude();
        });

        modelBuilder.Entity<Saleitem>(entity =>
        {
            entity.Ignore(e => e.Id); // Ignora o campo Id

            entity.HasKey(e => new { e.Saleid, e.Productid }).HasName("pk_saleitems");

            entity.ToTable("saleitems");

            entity.Property(e => e.Saleid).HasColumnName("saleid");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Amount).HasColumnName("amount");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("createdat")
                .HasDefaultValueSql("CURRENT_TIMESTAMP")  // Valor padrão no banco de dados
                .ValueGeneratedOnAdd();

            entity.HasOne(d => d.Product).WithMany(p => p.Saleitems)
                .HasForeignKey(d => d.Productid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_saleitems_products");

            entity.HasOne(d => d.Sale).WithMany(p => p.Saleitems)
                .HasForeignKey(d => d.Saleid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_saleitems_sales");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
