using CoreValidatorExample.BusinessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public interface IValidatorExecuterBase
    {
        List<SvcValidationMsg> Validate(object obj);
       
    }

}
