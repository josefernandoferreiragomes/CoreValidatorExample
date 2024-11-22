using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.Models
{
    // Proposal.cs
    public class Proposal
    {
        public string Title { get; set; }           // Proposal title
        public decimal Amount { get; set; }         // Proposed amount
        public ProposalStatus Status { get; set; }  // Status of the proposal
        public DateTime SubmissionDate { get; set; }  // Date the proposal was submitted

        public DateTime ProponentBirthDate { get; set; } // ProponentAge
        // Additional fields can be added as needed
    }

}
