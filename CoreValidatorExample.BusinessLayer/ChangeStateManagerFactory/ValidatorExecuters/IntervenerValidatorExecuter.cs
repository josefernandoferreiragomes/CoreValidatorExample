using CoreValidatorExample.BusinessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class IntervenerValidatorExecuter : ValidatorExecuterBase
    {
        public override List<SvcValidationMsg> Validate(object obj)
        {
            var svcValidationMsgsList = new List<SvcValidationMsg>();
            //perform validation logic
            return svcValidationMsgsList;
        }

        //remaining validation and execution methods

    }
}
