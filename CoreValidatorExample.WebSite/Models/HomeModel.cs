namespace CoreValidatorExample.WebSite.Models
{
    //to be removed direct references... and data accessd by API
    public class HomeModel
    {
        //IProposalService _proposalSvcRepository;
        //public HomeModel(IProposalService proposalSvcRepository)
        //{            
        //    _proposalSvcRepository = proposalSvcRepository;
        //    ChangeStateResultMessage = "State not changed yet";
        //}               


        //public string ChangeStateResultMessage { get; set; }                

        //public WFValidationResult<Proposal> ProposalChangeState(ProposalChangeStateSvcRequest request)
        //{
        //    try
        //    {
        //        WFValidationResult<Proposal> result;

        //        result = _proposalSvcRepository.ProposalChangeState(request);

        //        if (result != null && result.IsSuccess)
        //        {
        //            ChangeStateResultMessage = "State Change Successful";
        //        }
        //        else
        //        {
        //            ChangeStateResultMessage = "Error on State Change";
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        //TODO handle exception
        //        throw ex;
        //    }
            
        //}

        //public HomeViewModel GenerateViewModel()
        //{
        //    return new HomeViewModel()
        //    {
        //        ChangeStateResultMessage = this.ChangeStateResultMessage
        //    };
        //}

    }
}
