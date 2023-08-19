namespace CoreValidatorExample.APILibrary.Data
{
    public class WFValidationResult<T>
    {
        public bool IsSuccess { get; set; }
        public List<WFValidationMessage>? MessageList { get; set; }

        public T Value { get; set; }

        public WFValidationResult(T obj)
        {
            this.Value = obj;
            this.IsSuccess = true;
        }
    }
}
