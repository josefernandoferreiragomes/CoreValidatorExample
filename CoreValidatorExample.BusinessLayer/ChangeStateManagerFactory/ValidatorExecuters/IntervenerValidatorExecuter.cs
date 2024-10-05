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

        
        public List<SvcValidationMsg> ValidateAge(DateTime dateTime)
        {
            var svcValidationMsgsList = new List<SvcValidationMsg>();
            //perform validation logic

            // Perform date validation
            if (dateTime.AddYears(80)<DateTime.Today)
            {
                throw new InvalidOperationException("Intervener birth date is not allowed for these products.");
            }

            return svcValidationMsgsList;
        }

        //remaining validation and execution methods
    }
}
