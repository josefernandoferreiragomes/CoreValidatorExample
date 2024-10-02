using CoreValidatorExample.BusinessLayer.ChangeStateManager;
using CoreValidatorExample.BusinessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManager.ValidatorExecuters
{
    public class IntervenerValidatorExecuter : ValidatorExecuterBase
    {
        public override List<SvcValidationMsg> Validate()
        {
            var svcValidationMsgsList = new List<SvcValidationMsg>();
            //perform validation logic
            return svcValidationMsgsList;
        }

        //remaining validation and execution methods

    }
}
