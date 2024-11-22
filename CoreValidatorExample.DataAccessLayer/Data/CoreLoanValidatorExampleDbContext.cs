using CoreValidatorExample.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;

namespace CoreValidatorExample.DataAccessLayer.Data
{

    public class CoreLoanValidatorExampleDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Collateral> Collaterals { get; set; }
        public DbSet<Asset> Assets { get; set; }

        public CoreLoanValidatorExampleDbContext(DbContextOptions<CoreLoanValidatorExampleDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            base.OnConfiguring(optionsBuilder);
        }

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
                .HasForeignKey(l => l.CustomerId)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascade delete

            // Loan configuration
            modelBuilder.Entity<Loan>()
                .HasKey(l => l.LoanId);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Customer)
                .WithMany(c => c.LoanList)
                .HasForeignKey(l => l.CustomerId)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascade delete

            modelBuilder.Entity<Loan>()
                .HasMany(l => l.CollateralList)
                .WithOne(c => c.Loan)
                .HasForeignKey(c => c.LoanId)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascade delete

            // Collateral configuration
            modelBuilder.Entity<Collateral>()
                .HasKey(c => c.CollateralId);

            modelBuilder.Entity<Collateral>()
                .HasOne(c => c.Loan)
                .WithMany(l => l.CollateralList)
                .HasForeignKey(c => c.LoanId)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascade delete

            modelBuilder.Entity<Collateral>()
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascade delete

            modelBuilder.Entity<Collateral>()
                .HasMany(c => c.AssetIdList)
                .WithOne(a => a.Collateral)
                .HasForeignKey(a => a.CollateralId)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascade delete

            // Asset configuration
            modelBuilder.Entity<Asset>()
                .HasKey(a => a.AssetId);

            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Collateral)
                .WithMany(c => c.AssetIdList)
                .HasForeignKey(a => a.CollateralId)
                .OnDelete(DeleteBehavior.NoAction); // Disable cascade delete

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

            var loan1 = new Loan { LoanId = 1, LoanDescription = "Home Loan", LoanValue = 250000, CustomerId = 1 };
            var loan2 = new Loan { LoanId = 2, LoanDescription = "Car Loan", LoanValue = 30000, CustomerId = 2 };
            modelBuilder.Entity<Loan>().HasData(
                loan1,
                loan2
            );

            var collateral1 = new Collateral { CollateralId = 1, CollateralDescription = "House", CollateralValue = 300000, LoanId = 1, CustomerId = 1 };
            var collateral2 = new Collateral { CollateralId = 2, CollateralDescription = "Car", CollateralValue = 35000, LoanId = 2, CustomerId = 2 };
            modelBuilder.Entity<Collateral>().HasData(
                collateral1,
                collateral2
            );

            modelBuilder.Entity<Asset>().HasData(
                new Asset { AssetId = 1, AssetName = "House Asset", AssetValue = 300000, CollateralId = 1 },
                new Asset { AssetId = 2, AssetName = "Car Asset", AssetValue = 35000, CollateralId = 2 }
            );
#endif
        }


    }



}
