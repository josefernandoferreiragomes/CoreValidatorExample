using CoreValidatorExample.APILibrary.ChangeStateManager.ValidatorExecuters;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Interfaces;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Validators;

namespace CoreValidatorExample.APILibrary.ChangeStateManager.Factory
{
    public class ChangeStateManagerFactory
    {

        public IChangeStateManager GetObjectInstance<T>()
        {
            IChangeStateManager objInstance;
            switch (typeof(T).Name)
            {
                case "AppraisalChangeStateManager":
                    objInstance = (IChangeStateManager)Activator.CreateInstance(typeof(AppraisalChangeStateManager));
                    break;
                case "ProposalChangeStateManager":
                    objInstance = (IChangeStateManager)Activator.CreateInstance(typeof(ProposalChangeStateManager));
                    break;
                case "DecisionChangeStateManager":
                    objInstance = (IChangeStateManager)Activator.CreateInstance(typeof(DecisionChangeStateManager));
                    break;
                default:
                    throw new ArgumentNullException(nameof(objInstance));
            }
            
            return objInstance;
        }
    }

}
