using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.DataAccessLayer.Interfaces;
using CoreValidatorExample.DataAccessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.Services
{
    public interface IProposalService
    {
        WFValidationResult<Proposal> ProposalChangeState(ProposalChangeStateSvcRequest request);         
    }
    public class ProposalService : IProposalService
    {
        private ChangeStateManagerFactory<Proposal> _changeStateManagerFactory;
        private IGenericRepository<Proposal> _proposalRepository;

        public ProposalService(ChangeStateManagerFactory<Proposal> _changeStateManagerFactory, IGenericRepository<Proposal> proposalRepository)
        {
            //TODO add default IoC behaviour
            _changeStateManagerFactory = _changeStateManagerFactory;
            _proposalRepository = proposalRepository;
    }    

        //TO BE REFACTORED
        public WFValidationResult<Proposal> ProposalChangeState(ProposalChangeStateSvcRequest request)
        {

            WFValidationResult<Proposal> result = new WFValidationResult<Proposal>();
            //simulate success

            //Mock
            var proposal = _proposalRepository.GetByIdAsync(request.ProposalId);

            ProposalChangeStateManager<Proposal> manager = (ProposalChangeStateManager<Proposal>)_changeStateManagerFactory.GetObjectInstance(1, 101, 1001,proposal.Result);

            result = manager.ValidateAndExecute(request.EventId);

            return result;
        }
      
    }
}
