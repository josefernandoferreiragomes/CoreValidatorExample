using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator
{
    public class BaseServiceDataOrchestratorResult
    {
        
        public bool IsSuccess { get; set; }
        public bool ErrorMessage { get; set; }
    }
}
