namespace CoreValidatorExample.BusinessLayer.Models
{
    public class WFValidationResult<T>
    {
        public bool IsSuccess 
        {
            get
            {
                return !MessageList.Any();
            }
        }
        public List<SvcValidationMsg> MessageList { get; set; }

        public T? Value { get; set; }

        public WFValidationResult()
        {
            MessageList = new List<SvcValidationMsg>();
        }
        public WFValidationResult(T obj)
        {
            this.Value = obj;
            MessageList = new List<SvcValidationMsg>();
        }

    }
}
