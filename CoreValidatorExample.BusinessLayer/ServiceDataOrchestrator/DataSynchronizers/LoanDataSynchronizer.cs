using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.Interfaces;
using CoreValidatorExample.DataAccessLayer.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.DataSynchronizers
{
    internal class LoanDataSynchronizer : BaseDataSynchronizer
    {
        IGenericRepository<Loan> _mainRepository;
        
        public LoanDataSynchronizer(BaseDataSynchronizerRequest request, ILogger logger, IGenericRepository<Loan> mainRepository) : base(request, logger) 
        {
            _mainRepository = mainRepository;
            _result = new BaseServiceDataOrchestratorResult();
        }
        public override BaseServiceDataOrchestratorResult SynchronizeData()
        {

            try
            {
                //Get all loans to synchronize

                //Map data to External Web Service/API
                //Call External Web Service/API

                //Save results to database
            }
            catch (Exception ex) 
            {
                //experimental
                _logger.Log<LoanDataSynchronizer>(LogLevel.Error,new EventId(1),this,ex,null);
                throw ex;
            }
            return _result;
        }
    }
}
