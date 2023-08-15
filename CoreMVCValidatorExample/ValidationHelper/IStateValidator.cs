namespace CoreValidatorExample.WebSite.ValidationHelper
{
    public interface IStateValidator<T>
    {
        WFValidationResult Validate();
    }
}
