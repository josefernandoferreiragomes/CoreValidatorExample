using CoreValidatorExample.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;

namespace CoreValidatorExample.DataAccessLayer.Data
{

    public class CoreLoanValidatorExampleDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Collateral> Collaterals { get; set; }
        public DbSet<Asset> Assets { get; set; }

        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Appraisal> Appraisals { get; set; }
        public DbSet<Decision> Decisions { get; set; }
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
                .OnDelete(DeleteBehavior.NoAction);

            // Loan configuration
            modelBuilder.Entity<Loan>()
                .HasKey(l => l.LoanId);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Customer)
                .WithMany(c => c.LoanList)
                .HasForeignKey(l => l.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Loan>()
                .HasMany(l => l.CollateralList)
                .WithOne(c => c.Loan)
                .HasForeignKey(c => c.LoanId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Loan>()
                .Property(l=>l.LoanValue)
                .HasColumnType("decimal(18,2)");

            // Collateral configuration
            modelBuilder.Entity<Collateral>()
                .HasKey(c => c.CollateralId);

            modelBuilder.Entity<Collateral>()
                .HasOne(c => c.Loan)
                .WithMany(l => l.CollateralList)
                .HasForeignKey(c => c.LoanId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Collateral>()
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Collateral>()
                .HasMany(c => c.AssetIdList)
                .WithOne(a => a.Collateral)
                .HasForeignKey(a => a.CollateralId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Collateral>()
                .Property(c=> c.CollateralValue)
                .HasColumnType("decimal(18,2)");

            // Asset configuration
            modelBuilder.Entity<Asset>()
                .HasKey(a => a.AssetId);

            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Collateral)
                .WithMany(c => c.AssetIdList)
                .HasForeignKey(a => a.CollateralId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Asset>()
                .Property(a => a.AssetValue)
                .HasColumnType("decimal(18,2)");

            // Proposal configuration
            modelBuilder.Entity<Proposal>()
                .HasKey(p => p.ProposalId);

            modelBuilder.Entity<Proposal>()
                .Property(p => p.Title)
                .IsRequired();

            modelBuilder.Entity<Proposal>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Proposal>()
                .Property(p => p.Status)
                .IsRequired();

            modelBuilder.Entity<Proposal>()
                .Property(p => p.SubmissionDate)
                .IsRequired();

            modelBuilder.Entity<Proposal>()
                .Property(p => p.ProponentBirthDate)
                .IsRequired();

            // Appraisal configuration
            modelBuilder.Entity<Appraisal>()
                .HasKey(a => a.AppraisalId);

            modelBuilder.Entity<Appraisal>()
                .Property(a => a.MandatoryField)
                .IsRequired();

            modelBuilder.Entity<Appraisal>()
                .Property(a => a.Status)
                .IsRequired();

            modelBuilder.Entity<Appraisal>()
                .Property(a => a.SubmissionDate)
                .IsRequired();

            modelBuilder.Entity<Appraisal>()
                .Property(a => a.AppraiserName)
                .IsRequired();

            modelBuilder.Entity<Appraisal>()
                .Property(a => a.AppraisalScore)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<Appraisal>()
                .HasOne(a => a.Proposal)
                .WithMany()
                .HasForeignKey(a => a.ProposalId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Appraisal>()
                .HasOne(a => a.Asset)
                .WithMany()
                .HasForeignKey(a => a.AssetId)
                .OnDelete(DeleteBehavior.NoAction);

            // Decision configuration
            modelBuilder.Entity<Decision>()
                .HasKey(d => d.DecisionId);

            modelBuilder.Entity<Decision>()
                .Property(d => d.Reason)
                .IsRequired();

            modelBuilder.Entity<Decision>()
                .Property(d => d.Outcome)
                .IsRequired();

            modelBuilder.Entity<Decision>()
                .Property(d => d.DecisionDate)
                .IsRequired();

            modelBuilder.Entity<Decision>()
                .HasOne(d => d.Proposal)
                .WithMany()
                .HasForeignKey(d => d.ProposalId)
                .OnDelete(DeleteBehavior.NoAction);

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

            var proposal1 = new Proposal { ProposalId = 1, Title = "Proposal 1", Amount = 100000, Status = ProposalStatus.Pending, SubmissionDate = DateTime.Now, ProponentBirthDate = new DateTime(1980, 1, 1) };
            var proposal2 = new Proposal { ProposalId = 2, Title = "Proposal 2", Amount = 200000, Status = ProposalStatus.Approved, SubmissionDate = DateTime.Now, ProponentBirthDate = new DateTime(1990, 2, 2) };
            modelBuilder.Entity<Proposal>().HasData(
                proposal1,
                proposal2
            );

            var appraisal1 = new Appraisal { AppraisalId = 1, MandatoryField = "Field 1", Status = AppraisalStatus.Pending, SubmissionDate = DateTime.Now, AppraiserName = "Appraiser 1", ProposalId = 1, AssetId = 1, AppraisalScore = 85.5m };
            var appraisal2 = new Appraisal { AppraisalId = 2, MandatoryField = "Field 2", Status = AppraisalStatus.Approved, SubmissionDate = DateTime.Now, AppraiserName = "Appraiser 2", ProposalId = 2, AssetId = 2, AppraisalScore = 90.0m };
            modelBuilder.Entity<Appraisal>().HasData(
                appraisal1,
                appraisal2
            );

            var decision1 = new Decision { DecisionId = 1, Reason = "Reason 1", Outcome = DecisionOutcome.Accepted, DecisionDate = DateTime.Now, ProposalId = 1 };
            var decision2 = new Decision { DecisionId = 2, Reason = "Reason 2", Outcome = DecisionOutcome.Rejected, DecisionDate = DateTime.Now, ProposalId = 2 };
            modelBuilder.Entity<Decision>().HasData(
                decision1,
                decision2
            );
#endif
        }



    }



}
