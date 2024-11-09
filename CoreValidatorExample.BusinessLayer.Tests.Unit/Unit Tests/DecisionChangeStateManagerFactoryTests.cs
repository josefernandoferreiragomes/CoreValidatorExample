using NUnit.Framework;
using System;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using NUnit.Framework.Internal.Execution;

namespace CoreValidatorExample.BusinessLayer.Tests.Unit
{
    [TestFixture]
    public class DecisionChangeStateManagerFactoryTests
    {

        private DecisionChangeStateManager<Decision> _decisionChangeStateManager;
        int UserId;
        int CorporateStructureId;
        int DecisionId;
        Decision Decision;
        ChangeStateManagerFactory<Decision> ChangeStateManagerFactory;

        public DecisionChangeStateManagerFactoryTests(ChangeStateManagerFactory<Decision> changeStateManagerFactory)
        {
            ChangeStateManagerFactory = changeStateManagerFactory;
        }

        [SetUp]
        public void Setup()
        {
            // Initialize DecisionChangeStateManager using the factory pattern
            UserId = 1;
            CorporateStructureId = 1;
            DecisionId = 1;
            Decision = new Decision();
            _decisionChangeStateManager = (DecisionChangeStateManager<Decision>)ChangeStateManagerFactory.GetObjectInstance(UserId, CorporateStructureId, DecisionId);
            
        }
        //TO BE IMPLEMENTED
    }
}
