using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.DataAccessLayer.Data
{
    // ProposalStatus.cs
    public enum ProposalStatus
    {
        Pending = 1,    // Proposal is still pending
        Approved = 2,   // Proposal has been approved
        Rejected = 3,   // Proposal has been rejected
        InProgress = 4, // Proposal is currently being processed
        Completed = 5   // Proposal has been completed
    }

}
