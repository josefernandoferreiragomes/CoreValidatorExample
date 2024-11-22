using CoreValidatorExample.BusinessLayer.Repository;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.DataSynchronizers;
using CoreValidatorExample.BusinessLayer.Services;
using CoreValidatorExample.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator;
using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.DataAccessLayer.Data;

namespace CoreValidatorExample.WebAPI
{
    public class Startup(IConfiguration configuration)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Set up the logger factory to use the Debug provider
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddDebug() // Log to Debug Output
                    .SetMinimumLevel(LogLevel.Debug); // Set the desired log level
            });
            // Create an ILogger instance for LoanAssessmentService
            var logger = loggerFactory.CreateLogger<AppraisalService>();
            services.AddSingleton(typeof(Microsoft.Extensions.Logging.ILogger), logger);

            // DbContext
            services.AddDbContext<CoreLoanValidatorExampleDbContext>(options =>
                options
                    .UseSqlServer(configuration.GetConnectionString("CoreLoanValidatorExampleDB"))
                    .EnableSensitiveDataLogging()
                ,ServiceLifetime.Scoped
            );

            // Register generic repositories
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericRepository<Customer>), typeof(GenericRepository<Customer>));
            services.AddScoped(typeof(IGenericRepository<Loan>), typeof(GenericRepository<Loan>));
            services.AddScoped(typeof(IGenericRepository<Collateral>), typeof(GenericRepository<Collateral>));
            services.AddScoped(typeof(IGenericRepository<Asset>), typeof(GenericRepository<Asset>));
            services.AddScoped(typeof(IGenericRepository<Proposal>), typeof(GenericRepository<Proposal>));
            services.AddScoped(typeof(IGenericRepository<Decision>), typeof(GenericRepository<Decision>));
            services.AddScoped(typeof(IGenericRepository<Appraisal>), typeof(GenericRepository<Appraisal>));

            // Register ChangeStateManagerFactory for specific types
            services.AddScoped(typeof(IChangeStateManagerFactory<Appraisal>), typeof(ChangeStateManagerFactory<Appraisal>));
            services.AddScoped(typeof(IChangeStateManagerFactory<Proposal>), typeof(ChangeStateManagerFactory<Proposal>));
            services.AddScoped(typeof(IChangeStateManagerFactory<Decision>), typeof(ChangeStateManagerFactory<Decision>));

            // Register the generic ChangeStateManagerFactory
            services.AddScoped(typeof(ChangeStateManagerFactory<>));

            // Register data synchronizers
            services.AddScoped<IBaseDataSynchronizer, LoanDataSynchronizer>();
            services.AddScoped<IBaseDataSynchronizer, CollateralDataSynchronizer>();
            services.AddScoped<IBaseDataSynchronizer, AssetDataSynchronizer>();

            // Register orchestrators
            services.AddScoped<IBaseOrchestrator, LoanPhaseOneOrchestrator>();

            // Register services
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<ICollateralService, CollateralService>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAppraisalService, AppraisalService>();
            services.AddScoped<IProposalService, ProposalService>();

        }
    }
}
