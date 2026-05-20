using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ord.EF.Models;

namespace Ord.EF.Data;

public partial class OrdOracleContext : DbContext
{
    public OrdOracleContext(DbContextOptions<OrdOracleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryType> CategoryTypes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderLine> OrderLines { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductPrice> ProductPrices { get; set; }

    public virtual DbSet<VwProductMaxPriceIncrease> VwProductMaxPriceIncreases { get; set; }

    public virtual DbSet<VwProductPrice> VwProductPrices { get; set; }

    public virtual DbSet<Zip> Zips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("UD_PHILLIPM")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("SYS_C00260957");

            entity.ToTable("ADDRESS");

            entity.Property(e => e.AddressId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ADDRESS_ID");
            entity.Property(e => e.AddressCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ADDRESS_CRTD_DT");
            entity.Property(e => e.AddressCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ADDRESS_CRTD_ID");
            entity.Property(e => e.AddressLine1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_LINE1");
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_LINE2");
            entity.Property(e => e.AddressLine3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_LINE3");
            entity.Property(e => e.AddressUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ADDRESS_UPDT_DT");
            entity.Property(e => e.AddressUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ADDRESS_UPDT_ID");
            entity.Property(e => e.AddressZipcode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_ZIPCODE");

            entity.HasOne(d => d.AddressZipcodeNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AddressZipcode)
                .HasConstraintName("ADDRESS_FK1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("SYS_C00260945");

            entity.ToTable("CATEGORY");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CATEGORY_ID");
            entity.Property(e => e.CategoryCategoryTypeId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("CATEGORY_CATEGORY_TYPE_ID");
            entity.Property(e => e.CategoryCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("CATEGORY_CRTD_DT");
            entity.Property(e => e.CategoryCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CATEGORY_CRTD_ID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CATEGORY_NAME");
            entity.Property(e => e.CategoryPrntCategoryId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("CATEGORY_PRNT_CATEGORY_ID");
            entity.Property(e => e.CategoryUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("CATEGORY_UPDT_DT");
            entity.Property(e => e.CategoryUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CATEGORY_UPDT_ID");

            entity.HasOne(d => d.CategoryCategoryType).WithMany(p => p.Categories)
                .HasForeignKey(d => d.CategoryCategoryTypeId)
                .HasConstraintName("CATEGORY_FK2");

            entity.HasOne(d => d.CategoryPrntCategory).WithMany(p => p.InverseCategoryPrntCategory)
                .HasForeignKey(d => d.CategoryPrntCategoryId)
                .HasConstraintName("CATEGORY_FK1");
        });

        modelBuilder.Entity<CategoryType>(entity =>
        {
            entity.HasKey(e => e.CategoryTypeId).HasName("SYS_C00260939");

            entity.ToTable("CATEGORY_TYPE");

            entity.Property(e => e.CategoryTypeId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CATEGORY_TYPE_ID");
            entity.Property(e => e.CategoryTypeCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("CATEGORY_TYPE_CRTD_DT");
            entity.Property(e => e.CategoryTypeCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CATEGORY_TYPE_CRTD_ID");
            entity.Property(e => e.CategoryTypeDesc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CATEGORY_TYPE_DESC");
            entity.Property(e => e.CategoryTypeUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("CATEGORY_TYPE_UPDT_DT");
            entity.Property(e => e.CategoryTypeUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CATEGORY_TYPE_UPDT_ID");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("SYS_C00260963");

            entity.ToTable("CUSTOMER");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.CustomerCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("CUSTOMER_CRTD_DT");
            entity.Property(e => e.CustomerCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUSTOMER_CRTD_ID");
            entity.Property(e => e.CustomerFirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_FIRST_NAME");
            entity.Property(e => e.CustomerLastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_LAST_NAME");
            entity.Property(e => e.CustomerUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("CUSTOMER_UPDT_DT");
            entity.Property(e => e.CustomerUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUSTOMER_UPDT_ID");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => e.CustomerAddressId).HasName("SYS_C00260970");

            entity.ToTable("CUSTOMER_ADDRESS");

            entity.Property(e => e.CustomerAddressId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUSTOMER_ADDRESS_ID");
            entity.Property(e => e.CustomerAddressActvInd)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("CUSTOMER_ADDRESS_ACTV_IND");
            entity.Property(e => e.CustomerAddressAddressId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_ADDRESS_ADDRESS_ID");
            entity.Property(e => e.CustomerAddressCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("CUSTOMER_ADDRESS_CRTD_DT");
            entity.Property(e => e.CustomerAddressCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUSTOMER_ADDRESS_CRTD_ID");
            entity.Property(e => e.CustomerAddressCustomerId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("CUSTOMER_ADDRESS_CUSTOMER_ID");
            entity.Property(e => e.CustomerAddressDflt)
                .HasColumnType("NUMBER(1)")
                .HasColumnName("CUSTOMER_ADDRESS_DFLT");
            entity.Property(e => e.CustomerAddressUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("CUSTOMER_ADDRESS_UPDT_DT");
            entity.Property(e => e.CustomerAddressUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CUSTOMER_ADDRESS_UPDT_ID");

            entity.HasOne(d => d.CustomerAddressAddress).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerAddressAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CUSTOMER_ADDRESS_FK2");

            entity.HasOne(d => d.CustomerAddressCustomer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.CustomerAddressCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CUSTOMER_ADDRESS_FK1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrdersId).HasName("SYS_C00260983");

            entity.ToTable("ORDERS");

            entity.Property(e => e.OrdersId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDERS_ID");
            entity.Property(e => e.OrdersCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ORDERS_CRTD_DT");
            entity.Property(e => e.OrdersCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDERS_CRTD_ID");
            entity.Property(e => e.OrdersCustomerAddressId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ORDERS_CUSTOMER_ADDRESS_ID");
            entity.Property(e => e.OrdersCustomerId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ORDERS_CUSTOMER_ID");
            entity.Property(e => e.OrdersDate)
                .HasColumnType("DATE")
                .HasColumnName("ORDERS_DATE");
            entity.Property(e => e.OrdersOrderStatusId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ORDERS_ORDER_STATUS_ID");
            entity.Property(e => e.OrdersUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ORDERS_UPDT_DT");
            entity.Property(e => e.OrdersUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDERS_UPDT_ID");

            entity.HasOne(d => d.OrdersCustomerAddress).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrdersCustomerAddressId)
                .HasConstraintName("ORDERS_FK3");

            entity.HasOne(d => d.OrdersCustomer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrdersCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDERS_FK1");

            entity.HasOne(d => d.OrdersOrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrdersOrderStatusId)
                .HasConstraintName("ORDERS_FK2");
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasKey(e => e.OrderLineId).HasName("SYS_C00261015");

            entity.ToTable("ORDER_LINE");

            entity.Property(e => e.OrderLineId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDER_LINE_ID");
            entity.Property(e => e.OrderLineCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ORDER_LINE_CRTD_DT");
            entity.Property(e => e.OrderLineCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDER_LINE_CRTD_ID");
            entity.Property(e => e.OrderLineOrderId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ORDER_LINE_ORDER_ID");
            entity.Property(e => e.OrderLineProductId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ORDER_LINE_PRODUCT_ID");
            entity.Property(e => e.OrderLineQty)
                .HasPrecision(5)
                .HasColumnName("ORDER_LINE_QTY");
            entity.Property(e => e.OrderLineUnitPrice)
                .HasColumnType("NUMBER(9,2)")
                .HasColumnName("ORDER_LINE_UNIT_PRICE");
            entity.Property(e => e.OrderLineUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ORDER_LINE_UPDT_DT");
            entity.Property(e => e.OrderLineUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDER_LINE_UPDT_ID");

            entity.HasOne(d => d.OrderLineOrder).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OrderLineOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDER_LINE_FK1");

            entity.HasOne(d => d.OrderLineProduct).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OrderLineProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ORDER_LINE_FK2");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("SYS_C00260977");

            entity.ToTable("ORDER_STATUS");

            entity.Property(e => e.OrderStatusId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDER_STATUS_ID");
            entity.Property(e => e.OrderStatusCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ORDER_STATUS_CRTD_DT");
            entity.Property(e => e.OrderStatusCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDER_STATUS_CRTD_ID");
            entity.Property(e => e.OrderStatusDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ORDER_STATUS_DESC");
            entity.Property(e => e.OrderStatusUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ORDER_STATUS_UPDT_DT");
            entity.Property(e => e.OrderStatusUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ORDER_STATUS_UPDT_ID");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("SYS_C00260991");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.ProductId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.ProductCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_CRTD_DT");
            entity.Property(e => e.ProductCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_CRTD_ID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_NAME");
            entity.Property(e => e.ProductUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_UPDT_DT");
            entity.Property(e => e.ProductUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_UPDT_ID");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("SYS_C00261005");

            entity.ToTable("PRODUCT_CATEGORY");

            entity.HasIndex(e => new { e.ProductCategoryProductId, e.ProductCategoryCategoryId }, "PRODUCT_CATEGORY_UK1").IsUnique();

            entity.Property(e => e.ProductCategoryId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_CATEGORY_ID");
            entity.Property(e => e.ProductCategoryCategoryId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_CATEGORY_CATEGORY_ID");
            entity.Property(e => e.ProductCategoryCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_CATEGORY_CRTD_DT");
            entity.Property(e => e.ProductCategoryCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_CATEGORY_CRTD_ID");
            entity.Property(e => e.ProductCategoryEffDate)
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_CATEGORY_EFF_DATE");
            entity.Property(e => e.ProductCategoryProductId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_CATEGORY_PRODUCT_ID");
            entity.Property(e => e.ProductCategoryUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_CATEGORY_UPDT_DT");
            entity.Property(e => e.ProductCategoryUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_CATEGORY_UPDT_ID");

            entity.HasOne(d => d.ProductCategoryCategory).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.ProductCategoryCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PRODUCT_CATEGORY_FK2");

            entity.HasOne(d => d.ProductCategoryProduct).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.ProductCategoryProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PRODUCT_CATEGORY_FK1");
        });

        modelBuilder.Entity<ProductPrice>(entity =>
        {
            entity.HasKey(e => e.ProductPriceId).HasName("SYS_C00260997");

            entity.ToTable("PRODUCT_PRICE");

            entity.Property(e => e.ProductPriceId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_PRICE_ID");
            entity.Property(e => e.ProductPriceCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_PRICE_CRTD_DT");
            entity.Property(e => e.ProductPriceCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_PRICE_CRTD_ID");
            entity.Property(e => e.ProductPriceEffDate)
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_PRICE_EFF_DATE");
            entity.Property(e => e.ProductPricePrice)
                .HasColumnType("NUMBER(9,2)")
                .HasColumnName("PRODUCT_PRICE_PRICE");
            entity.Property(e => e.ProductPriceProductId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_PRICE_PRODUCT_ID");
            entity.Property(e => e.ProductPriceUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("PRODUCT_PRICE_UPDT_DT");
            entity.Property(e => e.ProductPriceUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PRODUCT_PRICE_UPDT_ID");

            entity.HasOne(d => d.ProductPriceProduct).WithMany(p => p.ProductPrices)
                .HasForeignKey(d => d.ProductPriceProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PRODUCT_PRICE_FK1");
        });

        modelBuilder.Entity<VwProductMaxPriceIncrease>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_PRODUCT_MAX_PRICE_INCREASE");

            entity.Property(e => e.PctIncrease)
                .HasColumnType("NUMBER")
                .HasColumnName("PCT_INCREASE");
            entity.Property(e => e.ProductId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_NAME");
            entity.Property(e => e.ProductPriceId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_PRICE_ID");
        });

        modelBuilder.Entity<VwProductPrice>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_PRODUCT_PRICE");

            entity.Property(e => e.EndDate)
                .HasColumnType("DATE")
                .HasColumnName("END_DATE");
            entity.Property(e => e.ProductId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_ID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_NAME");
            entity.Property(e => e.ProductPriceId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("PRODUCT_PRICE_ID");
            entity.Property(e => e.ProductPricePrice)
                .HasColumnType("NUMBER(9,2)")
                .HasColumnName("PRODUCT_PRICE_PRICE");
            entity.Property(e => e.StartDate)
                .HasColumnType("DATE")
                .HasColumnName("START_DATE");
        });

        modelBuilder.Entity<Zip>(entity =>
        {
            entity.HasKey(e => e.Zipcode).HasName("SYS_C00260952");

            entity.ToTable("ZIP");

            entity.Property(e => e.Zipcode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ZIPCODE");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("STATE");
            entity.Property(e => e.ZipCrtdDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ZIP_CRTD_DT");
            entity.Property(e => e.ZipCrtdId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ZIP_CRTD_ID");
            entity.Property(e => e.ZipUpdtDt)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ZIP_UPDT_DT");
            entity.Property(e => e.ZipUpdtId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ZIP_UPDT_ID");
            entity.Property(e => e.ZipcodeType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ZIPCODE_TYPE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
