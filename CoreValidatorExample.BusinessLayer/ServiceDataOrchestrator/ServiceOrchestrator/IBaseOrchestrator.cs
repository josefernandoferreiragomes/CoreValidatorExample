using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.DataSynchronizers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator
{
    public interface IBaseOrchestrator
    {
        
        public abstract Task<BaseServiceDataOrchestratorResult> Orchestrate(BaseOrchestratorRequest baseOrchestratorRequest);
    }
}
