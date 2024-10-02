namespace CoreValidatorExample.BusinessLayer.Data
{
    public interface IStateValidator<T>
    {
        WFValidationResult<T> ValidateSimple(T obj);
    }
}
