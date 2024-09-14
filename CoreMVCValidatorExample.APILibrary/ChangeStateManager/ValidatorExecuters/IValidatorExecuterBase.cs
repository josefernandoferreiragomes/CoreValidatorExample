using CoreValidatorExample.APILibrary.Data;
using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Data;

namespace CoreValidatorExample.APILibrary.ValidationFactoryConcept.Interfaces
{
    public interface IValidatorExecuterBase
    {
        List<SvcValidationMsg> Validate();
       
    }

}
