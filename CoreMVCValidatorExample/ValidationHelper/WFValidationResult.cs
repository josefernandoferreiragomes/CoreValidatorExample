namespace CoreValidatorExample.WebSite.ValidationHelper
{
    public class WFValidationResult
    {
        public bool IsSuccess { get; set; }
        public List<WFValidationMessage> MessageList { get; set; }
    }
}
