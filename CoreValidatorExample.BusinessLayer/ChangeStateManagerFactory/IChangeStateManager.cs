using CoreValidatorExample.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public interface IChangeStateManager<T>
    {
        void ExecuteChangeState();
        WFValidationResult<T> ValidateAndExecute(int eventId);
    }
}
