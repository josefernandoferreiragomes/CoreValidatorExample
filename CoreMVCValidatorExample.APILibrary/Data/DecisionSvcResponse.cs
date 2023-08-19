using CoreValidatorExample.APILibrary.Data;

namespace CoreValidatorExample.APILibrary.Data
{
    public class DecisionSvcResponse
    {
        public bool Success { get; set; }
        public List<SvcErrorMsg> SvcErrorMsgs { get; set; }
    }
}
