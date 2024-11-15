using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.DataSynchronizers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator
{
    public abstract class BaseOrchestrator : IBaseOrchestrator
    {
        public BaseOrchestratorRequest _baseOrchestratorRequest;
        public ILogger<BaseOrchestrator> _logger;
        public BaseOrchestrator(ILogger<BaseOrchestrator> logger) 
        {            
            _logger = logger;

            _result = new BaseServiceDataOrchestratorResult();
            _logger.Log(LogLevel.Information, "Orchestrator Started");
        }
        
        public BaseServiceDataOrchestratorResult _result;
        public abstract Task<BaseServiceDataOrchestratorResult> Orchestrate(BaseOrchestratorRequest baseOrchestratorRequest);
    }
}
