﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.DataAccessLayer.Data
{
    public class Collateral
    {
        [Key]
        public int CollateralId { get; set; }
        public string CollateralDescription { get; set; }

        public decimal CollateralValue { get; set; }
        public int LoanId { get; set; }
        public Loan Loan { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Asset> AssetIdList { get; set; }
    }
}
