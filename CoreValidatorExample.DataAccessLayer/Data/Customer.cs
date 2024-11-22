using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.DataAccessLayer.Data
{
    public class Customer
    {        

        [Key]
        public int CustomerId { get; set; }
        [MaxLength(50)]
        public string CustomerName { get; set; }
        public List<Loan>? LoanList { get; set; }
        public List<Collateral>? CollateralList { get; set; }
    }
}
