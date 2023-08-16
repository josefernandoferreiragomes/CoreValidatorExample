namespace CoreValidatorExample.WebSite.ValidationHelper
{
    public interface IStateValidator<T>
    {
        WFValidationResult<T> ValidateSimple(T obj);
    }
}
