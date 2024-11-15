using NUnit.Framework;
using System;
using CoreValidatorExample.DataAccessLayer.Data;
using CoreValidatorExample.DataAccessLayer;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.Interfaces;
using CoreValidatorExample.BusinessLayer.Repository;

using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;

using NUnit.Framework.Internal.Execution;
using Moq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.DataSynchronizers;

namespace CoreValidatorExample.BusinessLayer.Tests.Unit
{
    [TestFixture]
    public class AppraisalChangeStateManagerFactoryTests
    {
        ChangeStateManagerFactory<Appraisal> ChangeStateManagerFactory;
        private AppraisalChangeStateManager<Appraisal>     _appraisalChangeStateManager;
        int UserId;
        int CorporateStructureId;
        int AppraisalId;
        Appraisal Appraisal;
        IGenericRepository<Appraisal> _mockCustomerRepository;
        ServiceProvider _provider;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddSingleton<IBaseDataSynchronizer, LoanDataSynchronizer>();
            services.AddSingleton<IBaseDataSynchronizer, CollateralDataSynchronizer>();
            services.AddSingleton<IBaseDataSynchronizer, AssetDataSynchronizer>();
            services.AddSingleton<IBaseOrchestrator, LoanPhaseOneOrchestrator>();
            //services.AddSingleton(typeof(IChangeStateManagerFactory<>), typeof(ChangeStateManagerFactory<>));

            _provider = services.BuildServiceProvider();

            var loandatasync = (LoanDataSynchronizer)_provider.GetService<IBaseDataSynchronizer>();
            var loanrepository = _provider.GetService<IGenericRepository<Loan>>();
            // Initialize AppraisalChangeStateManager using the factory pattern           
            _appraisalChangeStateManager = (AppraisalChangeStateManager<Appraisal>)((ChangeStateManagerFactory<Appraisal>)_provider.GetService(
                typeof(ChangeStateManagerFactory<Appraisal>)))
                .GetObjectInstance(
                    UserId, 
                    CorporateStructureId, 
                    AppraisalId
            );            

        }

        [Test]
        public void ChangeState_MissingMandatoryField_ThrowsInvalidOperationException()
        {
            // Arrange
            Appraisal = new Appraisal
            {
                MandatoryField = null,  // Missing mandatory field
                Status = AppraisalStatus.Approved,
                SubmissionDate = DateTime.Now.AddDays(-1)                
            };
            int eventId = 1;
            _appraisalChangeStateManager.ObjectInstance = Appraisal;
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _appraisalChangeStateManager.ValidateAndExecute(eventId),
                "Expected an InvalidOperationException due to missing mandatory field.");
        }

        [Test]
        public void ChangeState_FutureSubmissionDate_ThrowsInvalidOperationException()
        {
            // Arrange
            Appraisal = new Appraisal
            {
                MandatoryField = "Performance Review",
                Status = AppraisalStatus.Approved,
                SubmissionDate = DateTime.Now.AddDays(1)  // Future date
            };
            int eventId = 1;
            _appraisalChangeStateManager.ObjectInstance = Appraisal;
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _appraisalChangeStateManager.ValidateAndExecute(eventId),
                "Expected an InvalidOperationException due to future submission date.");
        }

        [Test]
        public void ChangeState_InvalidStatus_ThrowsInvalidOperationException()
        {
            // Arrange
            Appraisal = new Appraisal
            {
                MandatoryField = "Performance Review",
                Status = AppraisalStatus.Pending,  // Invalid status for state change
                SubmissionDate = DateTime.Now.AddDays(-1)
            };
            int eventId = 1;
            _appraisalChangeStateManager.ObjectInstance = Appraisal;
            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _appraisalChangeStateManager.ValidateAndExecute(eventId),
                "Expected an InvalidOperationException due to invalid status.");
        }

        [Test]
        public void ChangeState_ValidAppraisal_DoesNotThrowException()
        {
            // Arrange
            Appraisal = new Appraisal
            {
                MandatoryField = "Performance Review",
                Status = AppraisalStatus.Approved,
                SubmissionDate = DateTime.Now.AddDays(-1)
            };
            int eventId = 1;
            _appraisalChangeStateManager.ObjectInstance = Appraisal;
            // Act & Assert
            Assert.DoesNotThrow(() => _appraisalChangeStateManager.ValidateAndExecute(eventId));
        }

        // Add more test cases as necessary for additional edge cases and factory behavior
    }
}
