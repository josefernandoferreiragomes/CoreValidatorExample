using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator
{
    public abstract class BaseOrchestrator
    {
        public BaseOrchestratorRequest _baseOrchestratorRequest;
        public ILogger<BaseOrchestrator> _logger;
        public BaseOrchestrator(BaseOrchestratorRequest baseOrchestratorRequest,
        ILogger<BaseOrchestrator> logger) 
        {
            _baseOrchestratorRequest = baseOrchestratorRequest;
            _logger = logger;

            _result = new BaseServiceDataOrchestratorResult();
            _logger.Log(LogLevel.Information, "Orchestrator Started");
        }

        public BaseServiceDataOrchestratorResult _result;
        public abstract Task<BaseServiceDataOrchestratorResult> Orchestrate();
    }
}
