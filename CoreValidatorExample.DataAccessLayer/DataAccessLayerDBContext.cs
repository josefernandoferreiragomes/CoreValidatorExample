using CoreValidatorExample.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;

namespace CoreValidatorExample.DataAccessLayer
{
    //public class GenericLoanDbContext : DbContext
    //{
    //    public DbSet<Customer> Customers { get; set; }
    //    public DbSet<Loan> Loans { get; set; }
    //    public DbSet<Collateral> Collaterals { get; set; }
    //    public DbSet<Asset> Assets { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        optionsBuilder.UseSqlite("Data Source=LoanDatabase"); // Use SQLite for a local database, or change this for other databases.
    //    }


    //}
    public class GenericLoanDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Collateral> Collaterals { get; set; }
        public DbSet<Asset> Assets { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customer configuration
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerName)
                .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.LoanList)
                .WithOne(l => l.Customer)
                .HasForeignKey(l => l.Customer.CustomerId);

            // Loan configuration
            modelBuilder.Entity<Loan>()
                .HasKey(l => l.LoanId);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Customer)
                .WithMany(c => c.LoanList)
                .HasForeignKey(l => l.Customer.CustomerId);

            modelBuilder.Entity<Loan>()
                .HasMany(l => l.CollateralList)
                .WithOne(c => c.Loan)
                .HasForeignKey(c => c.Loan.LoanId);

            // Collateral configuration
            modelBuilder.Entity<Collateral>()
                .HasKey(c => c.CollateralId);

            modelBuilder.Entity<Collateral>()
                .HasOne(c => c.Loan)
                .WithMany(l => l.CollateralList)
                .HasForeignKey(c => c.Loan.LoanId);

            modelBuilder.Entity<Collateral>()
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.Customer.CustomerId);

            modelBuilder.Entity<Collateral>()
                .HasMany(c => c.AssetList)
                .WithOne(a => a.Collateral)
                .HasForeignKey(a => a.Collateral.CollateralId);

            // Asset configuration
            modelBuilder.Entity<Asset>()
                .HasKey(a => a.AssetId);

            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Collateral)
                .WithMany(c => c.AssetList)
                .HasForeignKey(a => a.Collateral.CollateralId);

        #if DEBUG
            Console.WriteLine("Debug build and data seed");
            // !!! Test Only !!!
            // Seed data
            var customer1 = new Customer { CustomerId = 1, CustomerName = "John Doe" };
            var customer2 = new Customer { CustomerId = 2, CustomerName = "Jane Smith" };
            modelBuilder.Entity<Customer>().HasData(
                customer1,
                customer2
            );

            var loan1 = new Loan { LoanId = 1, LoanDescription = "Home Loan", LoanValue = 250000, Customer = customer1 };
            var loan2 = new Loan { LoanId = 2, LoanDescription = "Car Loan", LoanValue = 30000, Customer = customer2 };
            modelBuilder.Entity<Loan>().HasData(
                loan1,
                loan2
            );

            var collateral1 = new Collateral { CollateralId = 1, CollateralDescription = "House", CollateralValue = 300000, Loan = loan1, Customer = customer1 };
            var collateral2 = new Collateral { CollateralId = 2, CollateralDescription = "Car", CollateralValue = 35000, Loan = loan2, Customer = customer2 };
            modelBuilder.Entity<Collateral>().HasData(
            );

            modelBuilder.Entity<Asset>().HasData(
                new Asset { AssetId = 1, AssetName = "House Asset", AssetValue = 300000, Collateral = collateral1 },
                new Asset { AssetId = 2, AssetName = "Car Asset", AssetValue = 35000, Collateral = collateral2 }
            );
        #endif
        }
    }



}
