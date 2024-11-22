using CoreValidatorExample.DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.Services
{
    public interface ICollateralService
    {
        Task<IEnumerable<Collateral>> GetAllAsync();
    }
    public class CollateralService : ICollateralService
    {
        public Task<IEnumerable<Collateral>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
