using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.DataSynchronizers
{
    public class BaseDataSynchronizerRequest
    {
        public ServiceOrchestratorTypesEnum _serviceOrchestratorTypesEnum { get; set; }
        public string UserName { get; set; }
    }
}
