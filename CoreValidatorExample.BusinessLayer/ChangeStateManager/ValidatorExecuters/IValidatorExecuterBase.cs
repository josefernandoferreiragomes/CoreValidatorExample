using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Data;

namespace CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Interfaces
{
    public interface IValidatorExecuterBase
    {
        List<SvcValidationMsg> Validate();
       
    }

}
