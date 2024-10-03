using CoreValidatorExample.BusinessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.Data
{
    public abstract class SvcResponseBase
    {
        public bool Success { get; set; }
        public List<SvcErrorMsg>? SvcErrorMsgs { get; set; }
    }
}
