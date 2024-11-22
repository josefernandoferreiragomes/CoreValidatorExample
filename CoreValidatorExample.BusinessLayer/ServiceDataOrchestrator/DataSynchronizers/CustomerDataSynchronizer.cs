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
    public class CustomerDataSynchronizer : BaseDataSynchronizer
    {
        ICustomerService _mainRepository;
        
        public CustomerDataSynchronizer(ILogger logger, ICustomerService mainRepository) : base(logger) 
        {
            _mainRepository = mainRepository;
            _result = new BaseServiceDataOrchestratorResult();
        }
        public override BaseServiceDataOrchestratorResult SynchronizeData(BaseDataSynchronizerRequest baseDataSynchronizerRequest)
        {
            try
            {
                //Get all Customers to synchronize

                //Map data to External Web Service/API
                //Call External Web Service/API

                //Save results to database

                return _result;
            }
            catch (Exception ex)
            {
                //experimental
                _logger.Log<CustomerDataSynchronizer>(LogLevel.Error, new EventId(1), this, ex, null);
                throw ex;
            }
            return _result;
        }
    }
}
