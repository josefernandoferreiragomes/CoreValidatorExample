using CoreValidatorExample.BusinessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public interface IValidatorExecuterBase
    {
        List<SvcValidationMsg> Validate(object obj);
       
    }

}
