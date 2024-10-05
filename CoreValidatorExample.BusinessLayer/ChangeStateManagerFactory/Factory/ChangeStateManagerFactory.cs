using CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility;
using CoreValidatorExample.BusinessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class ChangeStateManagerFactory<T> where T : class
    {
        public T? ObjectInstance { get; set; }

        public IChangeStateManager<T> GetObjectInstance(int userId, int userCorporateUnitId, int itemId)
        {
            IChangeStateManager<T> objInstance;

            // Check the type of T and instantiate the appropriate manager
            switch (typeof(T).Name)
            {
                case nameof(Appraisal):
                    objInstance = (IChangeStateManager<T>)Activator.CreateInstance(
                        typeof(AppraisalChangeStateManager<>).MakeGenericType(typeof(T)), userId, userCorporateUnitId, itemId, ObjectInstance
                    );
                    break;

                case nameof(Proposal):
                    objInstance = (IChangeStateManager<T>)Activator.CreateInstance(
                        typeof(ProposalChangeStateManager<>).MakeGenericType(typeof(T)), userId, userCorporateUnitId, itemId, ObjectInstance
                    );
                    break;

                case nameof(Decision):
                    objInstance = (IChangeStateManager<T>)Activator.CreateInstance(
                        typeof(DecisionChangeStateManager<>).MakeGenericType(typeof(T)), userId, userCorporateUnitId, itemId, ObjectInstance
                    );
                    break;

                default:
                    throw new ArgumentException($"No matching ChangeStateManager found for {typeof(T).Name}");
            }

            return objInstance;
        }
    }


}
