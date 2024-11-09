using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.DataAccessLayer.Data
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }
        public string LoanDescription { get; set; }

        public decimal LoanValue { get; set; }

        public Customer Customer { get; set; }
        public List<Collateral>? CollateralList { get; set; }
    }
}
