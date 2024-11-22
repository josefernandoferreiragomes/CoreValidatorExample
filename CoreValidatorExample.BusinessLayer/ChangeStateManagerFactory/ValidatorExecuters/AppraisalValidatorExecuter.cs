using CoreValidatorExample.BusinessLayer.Models;

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

        public List<SvcValidationMsg> ValidateMandatoryField(Appraisal appraisal)
        {
            var svcValidationMsgsList = new List<SvcValidationMsg>();
            // Perform mandatory field validation
            if (string.IsNullOrEmpty(appraisal.MandatoryField))
            {
                throw new InvalidOperationException("Mandatory field is missing.");
            }

            return svcValidationMsgsList;
        }


        public List<SvcValidationMsg> ValidateStatus(Appraisal appraisal)
        {
            var svcValidationMsgsList = new List<SvcValidationMsg>();
            // Perform status validation
            if (appraisal.Status != AppraisalStatus.Approved)
            {
                throw new InvalidOperationException("Appraisal status is invalid.");
            }

            return svcValidationMsgsList;
        }
        //remaining validation and execution methods

    }
}
