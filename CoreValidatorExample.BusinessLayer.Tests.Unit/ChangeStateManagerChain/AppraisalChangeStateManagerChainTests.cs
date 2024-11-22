using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility;
using CoreValidatorExample.BusinessLayer.Models;
using NUnit.Framework;
using System;
using CoreValidatorExample.DataAccessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.Tests.Unit
{

    [TestFixture]
    public class AppraisalChangeStateManagerChainTests
    {
        private AppraisalChangeStateManager _changeStateManager;

        [SetUp]
        public void Setup()
        {
            _changeStateManager = new AppraisalChangeStateManager();
        }

        [Test]
        public void ChangeState_MissingMandatoryField_ThrowsInvalidOperationException()
        {
            // Arrange
            var appraisal = new Appraisal
            {
                MandatoryField = null,  // Missing mandatory field
                Status = AppraisalStatus.Approved,
                SubmissionDate = DateTime.Now.AddDays(-1)
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _changeStateManager.ChangeState(appraisal),
                "Mandatory field is missing.");
        }

        [Test]
        public void ChangeState_FutureSubmissionDate_ThrowsInvalidOperationException()
        {
            // Arrange
            var appraisal = new Appraisal
            {
                MandatoryField = "Performance Review",
                Status = AppraisalStatus.Approved,
                SubmissionDate = DateTime.Now.AddDays(1)  // Future date
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _changeStateManager.ChangeState(appraisal),
                "Appraisal submission date cannot be in the future.");
        }

        [Test]
        public void ChangeState_InvalidStatus_ThrowsInvalidOperationException()
        {
            // Arrange
            var appraisal = new Appraisal
            {
                MandatoryField = "Performance Review",
                Status = AppraisalStatus.Pending,  // Invalid status for state change
                SubmissionDate = DateTime.Now.AddDays(-1)
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _changeStateManager.ChangeState(appraisal),
                "Appraisal status is not approved.");
        }

        [Test]
        public void ChangeState_ValidAppraisal_DoesNotThrowException()
        {
            // Arrange
            var appraisal = new Appraisal
            {
                MandatoryField = "Performance Review",
                Status = AppraisalStatus.Approved,
                SubmissionDate = DateTime.Now.AddDays(-1)
            };

            // Act & Assert
            Assert.DoesNotThrow(() => _changeStateManager.ChangeState(appraisal));
        }

        // Add more test cases as needed for edge cases or additional properties
    }


}
