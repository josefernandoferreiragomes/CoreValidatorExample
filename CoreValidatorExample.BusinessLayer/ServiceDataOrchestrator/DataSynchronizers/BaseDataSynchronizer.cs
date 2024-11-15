using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.DataSynchronizers
{
    public abstract class BaseDataSynchronizer : IBaseDataSynchronizer
    {
        public BaseDataSynchronizerRequest _baseDataSynchronizerRequest;
        public ILogger _logger;
        public BaseDataSynchronizer(ILogger logger)
        {            
            _logger = logger;

            _logger.Log(LogLevel.Information, "Synchronizer Started");

            _result = new BaseServiceDataOrchestratorResult();
        }      
        protected BaseServiceDataOrchestratorResult _result { get; set; }
        public abstract BaseServiceDataOrchestratorResult SynchronizeData(BaseDataSynchronizerRequest baseDataSynchronizerRequest);
    }
}
