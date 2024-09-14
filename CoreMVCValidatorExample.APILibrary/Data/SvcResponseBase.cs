using CoreValidatorExample.APILibrary.Data;

namespace CoreValidatorExample.APILibrary.Data
{
    public abstract class SvcResponseBase
    {
        public bool Success { get; set; }
        public List<SvcErrorMsg>? SvcErrorMsgs { get; set; }
    }
}
