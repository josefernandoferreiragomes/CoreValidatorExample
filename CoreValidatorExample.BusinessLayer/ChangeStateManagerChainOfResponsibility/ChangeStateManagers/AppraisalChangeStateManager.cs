using CoreValidatorExample.DataAccessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // AppraisalChangeStateManager.cs
    public class AppraisalChangeStateManager
    {
        private readonly AppraisalChangeStateValidatorManager _validatorManager;

        public AppraisalChangeStateManager()
        {
            _validatorManager = new AppraisalChangeStateValidatorManager();
        }

        public void ChangeState(Appraisal appraisal)
        {
            // Perform validation
            _validatorManager.Validate(appraisal);

            // Change state logic
            // ...
        }
    }

}
