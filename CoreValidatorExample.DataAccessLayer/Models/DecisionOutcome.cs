using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.DataAccessLayer.Models
{
    // DecisionOutcome.cs
    public enum DecisionOutcome
    {
        Pending,    // Decision is still pending
        Accepted,   // Decision has been accepted
        Rejected    // Decision has been rejected
    }

}
