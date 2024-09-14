using CoreValidatorExample.APILibrary.ValidationFactoryConcept.Data;

namespace CoreValidatorExample.APILibrary.ValidationFactoryConcept.Interfaces
{
    public interface IValidatorFacConcept<T>
    {
        ValidationResultFacConcept Validate(T obj);
        ValidationResultFacConcept Validate(T obj, bool suppressWarnings);
    }

 
}
