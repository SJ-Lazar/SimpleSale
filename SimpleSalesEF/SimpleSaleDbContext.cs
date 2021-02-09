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

        public DbSet<Product> products {get;set;}

    }
}
