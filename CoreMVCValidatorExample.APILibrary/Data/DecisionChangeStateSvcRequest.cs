namespace CoreValidatorExample.APILibrary.Data
{
    public class DecisionChangeStateSvcRequest : SvcRequestBase
    {     
        public int DecisionId { get; set; }
        public int EventId { get; set; }
    }
}
