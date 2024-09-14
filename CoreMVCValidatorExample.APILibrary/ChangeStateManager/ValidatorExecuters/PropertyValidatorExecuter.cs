using CoreValidatorExample.APILibrary.ChangeStateManager;
using CoreValidatorExample.APILibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.APILibrary.ChangeStateManager.ValidatorExecuters
{
    public abstract class PropertyValidatorExecuter : ValidatorExecuterBase
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
