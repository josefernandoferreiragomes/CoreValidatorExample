using CoreValidatorExample.BusinessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.Models
{
    public abstract class SvcResponseBase
    {
        public bool Success { get; set; }
        public List<SvcErrorMsg>? SvcErrorMsgs { get; set; }
    }
}
