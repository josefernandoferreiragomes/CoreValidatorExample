using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.Models
{
    // Decision.cs
    public class Decision
    {
        public string Reason { get; set; }             // Reason for the decision
        public DecisionOutcome Outcome { get; set; }   // The outcome of the decision (e.g., Accepted, Rejected)
        public DateTime DecisionDate { get; set; }     // The date the decision was made

        // Additional fields can be added as necessary
    }

}
