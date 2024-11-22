using CoreValidatorExample.DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.Services
{
    public interface ILoanService
    {
        Task<IEnumerable<Loan>> GetAllAsync();
    }
    public class LoanService : ILoanService
    {
        public Task<IEnumerable<Loan>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
