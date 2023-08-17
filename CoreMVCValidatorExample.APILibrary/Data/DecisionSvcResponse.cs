using CoreMVCValidatorExample.APILibrary.ValidationHelper;

namespace CoreMVCValidatorExample.APILibrary.Data
{
    public class DecisionSvcResponse
    {
        public bool Success { get; set; }
        public List<SvcErrorMsg> SvcErrorMsgs { get; set; }
    }
}
