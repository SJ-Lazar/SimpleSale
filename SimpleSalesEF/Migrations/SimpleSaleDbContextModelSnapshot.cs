﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleSalesEF;

namespace SimpleSalesEF.Migrations
{
    [DbContext(typeof(SimpleSaleDbContext))]
    partial class SimpleSaleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("SimpleSalesDomain.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiscountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int>("UserModified")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("SimpleSalesDomain.Models.DiscountProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int>("UserModified")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DiscountOnProducts");
                });

            modelBuilder.Entity("SimpleSalesDomain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int>("UserModified")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SimpleSalesDomain.Models.ProductStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int>("UserModified")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ProductsStocks");
                });

            modelBuilder.Entity("SimpleSalesDomain.Models.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("AmountTendered")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Change")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int>("UserModified")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("SimpleSalesDomain.Models.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("SaleSubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SaleTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SaleTotalTax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int>("UserModified")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("SimpleSalesDomain.Models.SaleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<string>("Item")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ItemsPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceVat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int>("UserModified")
                        .HasColumnType("int");

                    b.Property<int>("ValueAddedTaxId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SalesItems");
                });

            modelBuilder.Entity("SimpleSalesDomain.Models.SpeacilOnProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SpeacilId")
                        .HasColumnType("int");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int>("UserModified")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SpeacilsOnProduct");
                });

            modelBuilder.Entity("SimpleSalesDomain.Models.Speacils", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpeacilName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SpeacilValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int>("UserModified")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Speacils");
                });

            modelBuilder.Entity("SimpleSalesDomain.Models.ValueAddedTax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserCreated")
                        .HasColumnType("int");

                    b.Property<int>("UserModified")
                        .HasColumnType("int");

                    b.Property<string>("VATName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("VATValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("ValueAddedTaxes");
                });
#pragma warning restore 612, 618
        }
    }
}
