﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.DataAccessLayer.Data
{
    // AppraisalStatus.cs
    public enum AppraisalStatus
    {
        Pending,     // Appraisal is still pending
        Approved,    // Appraisal has been approved
        Rejected,    // Appraisal has been rejected
        InProgress,  // Appraisal is currently in progress
        Completed    // Appraisal has been completed
    }

}