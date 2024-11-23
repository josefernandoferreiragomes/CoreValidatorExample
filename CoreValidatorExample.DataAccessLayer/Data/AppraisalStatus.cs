using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.DataAccessLayer.Data
{
    // AppraisalStatus.cs
    public enum AppraisalStatus
    {
        Pending = 1,     // Appraisal is still pending
        Approved = 2,    // Appraisal has been approved
        Rejected = 3,    // Appraisal has been rejected
        InProgress = 4,  // Appraisal is currently in progress
        Completed = 5    // Appraisal has been completed
    }

}
