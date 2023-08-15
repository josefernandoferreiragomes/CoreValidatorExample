using System.Dynamic;
using CoreValidatorExample.WebSite.Data;

namespace CoreValidatorExample.WebSite.ValidationHelper
{
    public class ProposalStateValidatorHelper : IStateValidator<ProposalSvcRequest>
    {
        private ProposalSvcRequest _request;

        public ProposalStateValidatorHelper(ProposalSvcRequest request)
        {
            _request = request;
        }

        public WFValidationResult Validate()
        {
            //simulate true
            WFValidationResult result = new WFValidationResult();
            result.MessageList = new List<WFValidationMessage>();



            switch (_request.ActionName)
            {
                case 1:
                    result.IsSuccess = ValidateStateTransfer1(_request);
                    break;
                case 2:
                    result.IsSuccess = ValidateStateTransfer2(_request);
                    break;

            }
            return result;
        }

        private bool ValidateStateTransfer2(ProposalSvcRequest request)
        {
            int businessLogicValue = 0;
            bool result = false;
            businessLogicValue = CallServiceA(request);
            result = businessLogicValue == 1;
            return result;
        }



        private bool ValidateStateTransfer1(ProposalSvcRequest request)
        {
            int businessLogicValue = 0;
            bool result = false;
            businessLogicValue = CallServiceB(request);
            result = businessLogicValue == 2;
            return result;
        }

        private int CallServiceA(ProposalSvcRequest request)
        {
            //simulate service call
            return 1;
        }

        private int CallServiceB(ProposalSvcRequest request)
        {
            //simulate service call
            return 2;
        }

    }
}
