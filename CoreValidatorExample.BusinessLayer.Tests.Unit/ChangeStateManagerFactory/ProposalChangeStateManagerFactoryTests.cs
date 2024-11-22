using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.DataAccessLayer.Models;

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
        ChangeStateManagerFactory<Proposal> ChangeStateManagerFactory;

        public ProposalChangeStateManagerFactoryTests(ChangeStateManagerFactory<Proposal> changeStateManagerFactory)
        {
            ChangeStateManagerFactory = changeStateManagerFactory;
        }

        [SetUp]
        public void Setup()
        {
            // Initialize ProposalChangeStateManager using the factory pattern
            UserId = 1;
            CorporateStructureId = 1;
            ProposalId = 1;
            Proposal = new Proposal();
            _proposalChangeStateManager = (ProposalChangeStateManager<Proposal>)ChangeStateManagerFactory.GetObjectInstance(UserId, CorporateStructureId, ProposalId, Proposal);
        }
        //TO BE IMPLEMENTED
    }
}
