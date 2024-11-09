using CoreValidatorExample.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoreValidatorExample.DataAccessLayer
{
    public class AppraisalDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Collateral> Collaterals { get; set; }
        public DbSet<Asset> Assets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=LoanlDatabase"); // Use SQLite for a local database, or change this for other databases.
        }
    }

}
