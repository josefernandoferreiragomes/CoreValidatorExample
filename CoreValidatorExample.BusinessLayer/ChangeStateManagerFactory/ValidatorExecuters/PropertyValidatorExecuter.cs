using CoreValidatorExample.BusinessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public abstract class PropertyValidatorExecuter : ValidatorExecuterBase
    {
        public override List<SvcValidationMsg> Validate()
        {
            var svcValidationMsgsList = new List<SvcValidationMsg>();
            //perform validation logic
            return svcValidationMsgsList;
        }

        //remaining validation and execution methods

    }
}
