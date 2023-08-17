namespace CoreMVCValidatorExample.APILibrary.ValidationHelper
{
    public interface IStateValidator<T>
    {
        WFValidationResult<T> ValidateSimple(T obj);
    }
}
