using CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Data;

namespace CoreValidatorExample.BusinessLayer.ValidationFactoryConcept.Interfaces
{
    public interface IValidatorFacConcept<T>
    {
        ValidationResultFacConcept Validate(T obj);
        ValidationResultFacConcept Validate(T obj, bool suppressWarnings);
    }

 
}
