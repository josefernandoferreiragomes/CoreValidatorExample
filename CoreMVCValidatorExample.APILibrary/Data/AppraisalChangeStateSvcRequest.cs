namespace CoreValidatorExample.APILibrary.Data
{
    public class AppraisalChangeStateSvcRequest : SvcRequestBase
    {
       
        public int AppraisalId { get; set; }
        public int EventId { get; set; }
    }
}
