using CoreValidatorExample.BusinessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public abstract class ValidatorExecuterBase : IValidatorExecuterBase
    {
        public abstract List<SvcValidationMsg> Validate(object obj);


    }
}
