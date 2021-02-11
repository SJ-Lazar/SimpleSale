using Microsoft.EntityFrameworkCore;
using SimpleSalesDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSalesEF
{
    public class SimpleSaleDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server =.\SQLEXPRESS; Database = SimpleSale; Trusted_Connection = True;");
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductStock> ProductsStocks { get; set; }

        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SalesItems { get; set; }

        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountProduct> DiscountOnProducts { get; set; }

        public DbSet<ValueAddedTax> ValueAddedTaxes { get; set; }
        public DbSet<Speacils> Speacils { get; set; }
        public DbSet<SpeacilOnProduct> SpeacilsOnProduct { get; set; }

    }
}
