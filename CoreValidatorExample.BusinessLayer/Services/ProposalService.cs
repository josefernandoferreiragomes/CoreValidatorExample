using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.BusinessLayer.Models;
using CoreValidatorExample.DataAccessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.Services
{
    public interface IProposalService
    {
        WFValidationResult<Proposal> ProposalChangeState(ProposalChangeStateSvcRequest request);         
    }
    public class ProposalService : IProposalService
    {
        private ChangeStateManagerFactory<Proposal> ChangeStateManagerFactory;

        public ProposalService(ChangeStateManagerFactory<Proposal> changeStateManagerFactory)
        {
            //TODO add default IoC behaviour
            this.ChangeStateManagerFactory = changeStateManagerFactory;
        }    

        //TO BE REFACTORED
        public WFValidationResult<Proposal> ProposalChangeState(ProposalChangeStateSvcRequest request)
        {

            WFValidationResult<Proposal> result = new WFValidationResult<Proposal>();
            //simulate success

            //Mock
            Proposal proposal = new Proposal();

            ProposalChangeStateManager<Proposal> manager = (ProposalChangeStateManager<Proposal>)ChangeStateManagerFactory.GetObjectInstance(1, 101, 1001);

            result = manager.ValidateAndExecute(request.EventId);

            return result;
        }
      
    }
}
