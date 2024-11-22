using CoreValidatorExample.BusinessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public abstract class ValidatorExecuterBase : IValidatorExecuterBase
    {
        public abstract List<SvcValidationMsg> Validate(object obj);


    }
}
