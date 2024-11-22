using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.BusinessLayer.Repository;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.DataSynchronizers;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator;
using CoreValidatorExample.BusinessLayer.Services;
using CoreValidatorExample.DataAccessLayer;
using CoreValidatorExample.DataAccessLayer.Interfaces;
using CoreValidatorExample.DataAccessLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using MoqExt;
using NUnit.Framework.Internal;

namespace CoreValidatorExample.BusinessLayer.Tests.Unit
{
    [TestFixture]
    public class AppraisalChangeStateManagerFactoryTests
    {
        private Mock<IGenericRepository<Appraisal>> _mockAppraisalRepository;
        private IAppraisalService _service;
        ServiceProvider _provider;

        [SetUp]
        public void Setup()
        {           
            var services = new ServiceCollection();

            _mockAppraisalRepository = new Mock<IGenericRepository<Appraisal>>();
            
            services.AddSingleton(typeof(IGenericRepository<Appraisal>), _mockAppraisalRepository.Object);
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<GenericLoanDbContext>();            
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<ICollateralService, CollateralService>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<ICustomerService, CustomerService>();            
            services.AddScoped<IAppraisalService, AppraisalService>();
            services.AddScoped<IProposalService, ProposalService>();
            services.AddScoped<IBaseDataSynchronizer, LoanDataSynchronizer>();
            services.AddScoped<IBaseDataSynchronizer, CollateralDataSynchronizer>();
            services.AddScoped<IBaseDataSynchronizer, AssetDataSynchronizer>();
            services.AddScoped<IBaseOrchestrator, LoanPhaseOneOrchestrator>();
            
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
            
            services.AddSingleton(typeof(IChangeStateManagerFactory<>), typeof(ChangeStateManagerFactory<>));
            services.AddSingleton(typeof(IServiceProvider), services);
            _provider = services.BuildServiceProvider();
            _service = _provider.GetService<IAppraisalService>();
        }

        [Test]
        public void ChangeState_MissingMandatoryField_ThrowsInvalidOperationException()
        {
            // Arrange
            int UserId = 1;
            int CorporateStructureId = 1;            
            
            var mockAppraisal = new Appraisal
            {
                
                MandatoryField = null,  // Missing mandatory field
                Status = AppraisalStatus.Approved,
                SubmissionDate = DateTime.Now.AddDays(-1)                
            };
            _mockAppraisalRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(mockAppraisal);
                    
            var request = new AppraisalChangeStateSvcRequest()
            {
                ActionName = 2,
                EventId = 1,
                AppraisalId = 1,
                UserCorporateUnitId = CorporateStructureId,
                UserId = UserId
            };
                        
            Assert.Throws<InvalidOperationException>(() => _service.AppraisalChangeState(request),
                "Expected an InvalidOperationException due to missing mandatory field.");
        }

        [Test]
        public void ChangeState_FutureSubmissionDate_ThrowsInvalidOperationException()
        {
            // Arrange
            int UserId = 1;
            int CorporateStructureId = 1;

            var mockAppraisal = new Appraisal
            {
                MandatoryField = "Performance Review",
                Status = AppraisalStatus.Approved,
                SubmissionDate = DateTime.Now.AddDays(1)  // Future date
            };
            _mockAppraisalRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(mockAppraisal);

            var request = new AppraisalChangeStateSvcRequest()
            {
                ActionName = 2,
                EventId = 1,
                AppraisalId = 1,
                UserCorporateUnitId = CorporateStructureId,
                UserId = UserId
            };            
           
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _service.AppraisalChangeState(request),
                "Expected an InvalidOperationException due to future submission date.");
        }

        [Test]
        public void ChangeState_InvalidStatus_ThrowsInvalidOperationException()
        {
            // Arrange
            int UserId = 1;
            int CorporateStructureId = 1;
            var mockAppraisal = new Appraisal
            {
                MandatoryField = "Performance Review",
                Status = AppraisalStatus.Pending,  // Invalid status for state change
                SubmissionDate = DateTime.Now.AddDays(-1)
            };
            _mockAppraisalRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(mockAppraisal);

            var request = new AppraisalChangeStateSvcRequest()
            {
                ActionName = 2,
                EventId = 2,
                AppraisalId = 1,
                UserCorporateUnitId = CorporateStructureId,
                UserId = UserId
            };
           
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _service.AppraisalChangeState(request),
                "Expected an InvalidOperationException due to invalid status.");
        }

        [Test]
        public void ChangeState_ValidAppraisal_DoesNotThrowException()
        {
            // Arrange
            int UserId = 1;
            int CorporateStructureId = 1;

            var mockAppraisal = new Appraisal
            {
                MandatoryField = "Performance Review",
                Status = AppraisalStatus.Approved,
                SubmissionDate = DateTime.Now.AddDays(-1)
            };
            _mockAppraisalRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(mockAppraisal);

            var request = new AppraisalChangeStateSvcRequest()
            {
                ActionName = 2,
                EventId = 1,
                AppraisalId = 1,
                UserCorporateUnitId = CorporateStructureId,
                UserId = UserId
            };

            // Act & Assert
            Assert.DoesNotThrow(() => _service.AppraisalChangeState(request));
        }

        // Add more test cases as necessary for additional edge cases and factory behavior
    }
}
