namespace CoreValidatorExample.APILibrary.Data
{
    public interface IStateValidator<T>
    {
        WFValidationResult<T> ValidateSimple(T obj);
    }
}
