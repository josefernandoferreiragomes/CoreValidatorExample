using CoreValidatorExample.APILibrary.ChangeStateManager.ValidatorExecuters;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Interfaces;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Validators;

namespace CoreValidatorExample.APILibrary.ChangeStateManager.Factory
{
    public class ChangeStateManagerFactory
    {

        public IChangeStateManager GetObjectInstance<T>(int userId, int userCorporateUnitId, int itemId)
        {
            IChangeStateManager objInstance;
            switch (typeof(T).Name)
            {
                case "AppraisalChangeStateManager":
                    objInstance = (AppraisalChangeStateManager)Activator.CreateInstance(typeof(AppraisalChangeStateManager), userId, userCorporateUnitId, itemId);
                    break;
                case "ProposalChangeStateManager":
                    objInstance = (ProposalChangeStateManager)Activator.CreateInstance(typeof(ProposalChangeStateManager), userId, userCorporateUnitId, itemId);
                    break;
                case "DecisionChangeStateManager":
                    objInstance = (DecisionChangeStateManager)Activator.CreateInstance(typeof(DecisionChangeStateManager), userId, userCorporateUnitId, itemId);
                    break;
                default:
                    throw new ArgumentNullException(nameof(objInstance));
            }
            
            return objInstance;
        }
    }

}
