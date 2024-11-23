using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.DataAccessLayer.Data
{
    // DecisionOutcome.cs
    public enum DecisionOutcome
    {
        Pending = 1,    // Decision is still pending
        Accepted = 2,   // Decision has been accepted
        Rejected = 3   // Decision has been rejected
    }

}
