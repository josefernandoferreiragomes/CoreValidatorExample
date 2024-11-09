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
    internal class CollateralDataSynchronizer : BaseDataSynchronizer
    {
        IGenericRepository<Collateral> _mainRepository;
        
        public CollateralDataSynchronizer(BaseDataSynchronizerRequest request, ILogger logger, IGenericRepository<Collateral> mainRepository) : base(request, logger) 
        {
            _mainRepository = mainRepository;
            _result = new BaseServiceDataOrchestratorResult();
        }
        public override BaseServiceDataOrchestratorResult SynchronizeData()
        {

            //Get all Collaterals to synchronize

            //Map data to External Web Service/API
            //Call External Web Service/API

            //Save results to database

            return _result;
        }
    }
}
