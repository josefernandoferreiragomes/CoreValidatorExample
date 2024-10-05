using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.Repository;

namespace CoreValidatorExample.WebSite.Models
{
    public class HomeModel
    {
        IProposalSvcRepository _proposalSvcRepository;
        public HomeModel(IProposalSvcRepository proposalSvcRepository)
        {            
            _proposalSvcRepository = proposalSvcRepository;
            ChangeStateResultMessage = "State not changed yet";
        }               


        public string ChangeStateResultMessage { get; set; }                

        public WFValidationResult<Proposal> ProposalChangeState(ProposalChangeStateSvcRequest request)
        {
            try
            {
                WFValidationResult<Proposal> result;

                result = _proposalSvcRepository.ProposalChangeState(request);

                if (result != null && result.IsSuccess)
                {
                    ChangeStateResultMessage = "State Change Successful";
                }
                else
                {
                    ChangeStateResultMessage = "Error on State Change";
                }
                return result;
            }
            catch (Exception ex)
            {
                //TODO handle exception
                throw ex;
            }
            
        }

        public HomeViewModel GenerateViewModel()
        {
            return new HomeViewModel()
            {
                ChangeStateResultMessage = this.ChangeStateResultMessage
            };
        }

    }
}
