using CoreValidatorExample.BusinessLayer.Services;
using Microsoft.Extensions.Logging;

namespace CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.DataSynchronizers
{
    public class CollateralDataSynchronizer : BaseDataSynchronizer
    {
        ICollateralService _mainRepository;
        
        public CollateralDataSynchronizer(ILogger logger, ICollateralService mainRepository) : base(logger) 
        {
            _mainRepository = mainRepository;
            _result = new BaseServiceDataOrchestratorResult();
        }
        public override BaseServiceDataOrchestratorResult SynchronizeData(BaseDataSynchronizerRequest baseDataSynchronizerRequest)
        {

            //Get all Collaterals to synchronize

            //Map data to External Web Service/API
            //Call External Web Service/API

            //Save results to database

            return _result;
        }
    }
}
