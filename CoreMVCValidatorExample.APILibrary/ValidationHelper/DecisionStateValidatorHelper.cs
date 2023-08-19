using System.Dynamic;
using CoreValidatorExample.APILibrary.Data;

namespace CoreValidatorExample.APILibrary.Data
{
    //public class DecisionStateValidatorHelper : IStateValidator<DecisionSvcRequest>
    //{
    //    public WFValidationResult Validate(DecisionSvcRequest request)
    //    {
    //        //simulate true
    //        WFValidationResult result = new WFValidationResult();
    //        result.MessageList = new List<WFValidationMessage>();



    //        switch (request.ActionName)
    //        {
    //            case 1:
    //                result.IsSuccess = ValidateStateTransfer3(request);
    //                break;
    //            case 2:
    //                result.IsSuccess = ValidateStateTransfer4(request);
    //                break;

    //        }
    //        return result;
    //    }

    //    private bool ValidateStateTransfer3(DecisionSvcRequest request)
    //    {
    //        int businessLogicValue = 0;
    //        bool result = false;
    //        businessLogicValue = CallServiceZ(request);
    //        result = businessLogicValue == 1;
    //        return result;
    //    }



    //    private bool ValidateStateTransfer4(DecisionSvcRequest request)
    //    {
    //        int businessLogicValue = 0;
    //        bool result = false;
    //        businessLogicValue = CallServiceY(request);
    //        result = businessLogicValue == 2;
    //        return result;
    //    }

    //    private int CallServiceZ(DecisionSvcRequest request)
    //    {
    //        //simulate service call
    //        return 1;
    //    }

    //    private int CallServiceY(DecisionSvcRequest request)
    //    {
    //        //simulate service call
    //        return 2;
    //    }

    //}
}
