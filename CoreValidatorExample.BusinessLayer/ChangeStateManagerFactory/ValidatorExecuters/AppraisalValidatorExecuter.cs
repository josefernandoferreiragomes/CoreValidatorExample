using CoreValidatorExample.BusinessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class AppraisalValidatorExecuter : ValidatorExecuterBase
    {
        public override List<SvcValidationMsg> Validate(object obj)
        {
            var svcValidationMsgsList = new List<SvcValidationMsg>();
            //perform validation logic

            // Perform date validation
            if ((DateTime)obj > DateTime.Now)
            {
                throw new InvalidOperationException("Submission date is in the future.");
            }

            return svcValidationMsgsList;
        }

        //remaining validation and execution methods

    }
}
