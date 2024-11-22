using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.DataAccessLayer.Models
{
    // ProposalStatus.cs
    public enum ProposalStatus
    {
        Pending,    // Proposal is still pending
        Approved,   // Proposal has been approved
        Rejected,   // Proposal has been rejected
        InProgress, // Proposal is currently being processed
        Completed   // Proposal has been completed
    }

}
