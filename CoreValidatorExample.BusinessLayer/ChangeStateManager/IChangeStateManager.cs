using CoreValidatorExample.BusinessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManager
{
    public interface IChangeStateManager
    {
        void ExecuteChangeState();
        List<SvcValidationMsg> ValidateAndExecute(int eventId);
    }
}
