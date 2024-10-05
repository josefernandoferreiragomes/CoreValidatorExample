namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class ChangeStateManagerFactory
    {

        public IChangeStateManager<T> GetObjectInstance<T>(int userId, int userCorporateUnitId, int itemId)
        {
            IChangeStateManager<T> objInstance;
            switch (typeof(T).Name)
            {
                case "AppraisalChangeStateManager":
                    objInstance = (AppraisalChangeStateManager<T>)Activator.CreateInstance(typeof(AppraisalChangeStateManager<T>), userId, userCorporateUnitId, itemId);
                    break;
                case "ProposalChangeStateManager":
                    objInstance = (ProposalChangeStateManager<T>)Activator.CreateInstance(typeof(ProposalChangeStateManager<T>), userId, userCorporateUnitId, itemId);
                    break;
                case "DecisionChangeStateManager":
                    objInstance = (DecisionChangeStateManager<T>)Activator.CreateInstance(typeof(DecisionChangeStateManager<T>), userId, userCorporateUnitId, itemId);
                    break;
                default:
                    throw new ArgumentNullException(nameof(objInstance));
            }
            
            return objInstance;
        }
    }

}
