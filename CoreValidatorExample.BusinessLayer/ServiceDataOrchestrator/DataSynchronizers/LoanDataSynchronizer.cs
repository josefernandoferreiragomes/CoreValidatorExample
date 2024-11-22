using CoreValidatorExample.BusinessLayer.Models;

using CoreValidatorExample.DataAccessLayer.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreValidatorExample.BusinessLayer.Services;

namespace CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.DataSynchronizers
{
    public class LoanDataSynchronizer : BaseDataSynchronizer
    {
        ILoanService _mainRepository;
        
        public LoanDataSynchronizer(ILogger logger, ILoanService mainRepository) : base(logger) 
        {
            _mainRepository = mainRepository;
            _result = new BaseServiceDataOrchestratorResult();
        }        
        public override BaseServiceDataOrchestratorResult SynchronizeData(BaseDataSynchronizerRequest baseDataSynchronizerRequest)
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
