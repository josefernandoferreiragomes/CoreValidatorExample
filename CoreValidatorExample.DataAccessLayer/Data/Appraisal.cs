using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.DataAccessLayer.Data
{
    // Appraisal.cs
    public class Appraisal
    {
        public string MandatoryField { get; set; }      // Example of a mandatory field
        public AppraisalStatus Status { get; set; }     // Status of the appraisal (e.g., Approved, Pending, Rejected)
        public DateTime SubmissionDate { get; set; }    // Date the appraisal was submitted

        // Other potential fields related to the appraisal
        public string AppraiserName { get; set; }       // Name of the person doing the appraisal
        public string AppraiseeName { get; set; }       // Name of the person being appraised
        public decimal AppraisalScore { get; set; }     // Score from the appraisal

        // You can add additional fields as necessary based on your use case
    }

}
