namespace CoreValidatorExample.BusinessLayer.Data
{
    public class WFValidationResult<T>
    {
        public bool IsSuccess { get; set; }
        public List<SvcValidationMsg>? MessageList { get; set; }

        public T? Value { get; set; }

        public WFValidationResult()
        {
        }
        public WFValidationResult(T obj)
        {
            this.Value = obj;
            this.IsSuccess = true;
        }

    }
}
