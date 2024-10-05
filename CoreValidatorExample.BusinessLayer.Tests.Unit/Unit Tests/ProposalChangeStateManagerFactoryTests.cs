using NUnit.Framework;
using System;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using NUnit.Framework.Internal.Execution;

namespace CoreValidatorExample.BusinessLayer.Tests.Unit
{
    [TestFixture]
    public class ProposalChangeStateManagerFactoryTests
    {
        private ProposalChangeStateManager<Proposal> _proposalChangeStateManager;
        int UserId;
        int CorporateStructureId;
        int ProposalId;
        Proposal Proposal;

        [SetUp]
        public void Setup()
        {
            // Initialize ProposalChangeStateManager using the factory pattern
            UserId = 1;
            CorporateStructureId = 1;
            ProposalId = 1;
            Proposal = new Proposal();
            _proposalChangeStateManager = new ProposalChangeStateManager<Proposal>(UserId, CorporateStructureId, ProposalId, Proposal);
        }
        //TO BE IMPLEMENTED
    }
}
