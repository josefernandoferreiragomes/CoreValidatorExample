using CoreValidatorExample.BusinessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public abstract class ChangeStateManagerBase<T> : IChangeStateManager<T>
    {
        public T? ObjectInstance { get; set; }
        protected ChangeStateManagerBase(int userId, int userCorporateUnitId)
        {
            UserId = userId;
            UserCorporateUnitId = userCorporateUnitId;
            ValidationMsgList = new List<SvcValidationMsg>();
            ValidatorExecuterFactory = new ValidatorExecuterFactory();
        }

        protected ValidatorExecuterFactory ValidatorExecuterFactory;
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int UserCorporateUnitId { get; set; }

        protected List<SvcValidationMsg> ValidationMsgList { get; set; }

        public abstract WFValidationResult<T> ValidateAndExecute(int eventId);

        public abstract void ExecuteChangeState();

        public void NoValidationsExecuteStateChange()
        {
            ExecuteChangeState();
        }
    }
}
