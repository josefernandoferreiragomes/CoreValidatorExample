using CoreValidatorExample.APILibrary.ChangeStateManager.ValidatorExecuters;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Interfaces;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Validators;

namespace CoreValidatorExample.APILibrary.ChangeStateManager.Factory
{
    public class ValidatorExecuterFactory
    {

        public IValidatorExecuterBase GetObjectInstance<T>()
        {
            IValidatorExecuterBase objInstance;
            switch (typeof(T).Name)
            {
                case "AppraisalValidatorExecuter":
                    objInstance = (IValidatorExecuterBase)Activator.CreateInstance(typeof(AppraisalValidatorExecuter));
                    break;
                case "IntervenerValidatorExecuter":
                    objInstance = (IValidatorExecuterBase)Activator.CreateInstance(typeof(IntervenerValidatorExecuter));
                    break;
                case "PropertyValidatorExecuter":
                    objInstance = (IValidatorExecuterBase)Activator.CreateInstance(typeof(PropertyValidatorExecuter));
                    break;
                default:
                    throw new ArgumentNullException(nameof(objInstance));
            }
            
            return objInstance;
        }
    }

}
