using CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.WebAPI;

namespace CoreValidatorExample.BusinessLayer.Repository
{
    public interface IProposalSvcRepository
    {

        public string GetDataFromApi();

        //TO BE REFACTORED
        public WFValidationResult<Proposal> ProposalChangeState(ProposalChangeStateSvcRequest request);
       

    }
}