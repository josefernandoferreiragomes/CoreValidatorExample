using CoreValidatorExample.BusinessLayer.Interfaces;
using CoreValidatorExample.BusinessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreValidatorExample.BusinessLayer.Data;
using Microsoft.Extensions.Logging;
using CoreValidatorExample.BusinessLayer.WebAPI;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.DataSynchronizers;
using CoreValidatorExample.DataAccessLayer.Data;

namespace CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator
{
    public class CustomerPhaseOneOrchestrator : BaseOrchestrator
    {
        private readonly IEnumerable<IBaseDataSynchronizer> _dataSynchronizers;
        public IBaseDataSynchronizer _customerDataSynchronizer;
        public IBaseDataSynchronizer _loanDataSynchronizer;
        ILogger<CustomerPhaseOneOrchestrator> _logger;
        public int _customerId;
        WebAPIClassReference _externalApiService;        

        public CustomerPhaseOneOrchestrator(
            ILogger<CustomerPhaseOneOrchestrator> logger,
            IEnumerable<IBaseDataSynchronizer> dataSynchronizers
        )
            : base (logger)
        {
            this._logger = logger;
            _dataSynchronizers = dataSynchronizers;
            this._loanDataSynchronizer = _dataSynchronizers.OfType<LoanDataSynchronizer>().FirstOrDefault();
            this._customerDataSynchronizer = _dataSynchronizers.OfType<CustomerDataSynchronizer>().FirstOrDefault();
        }
        public override async Task<BaseServiceDataOrchestratorResult> Orchestrate(BaseOrchestratorRequest baseOrchestratorRequest)
        {
            try
            {
                //TODO for all, sync//TODO for all, sync
                var customerDataSynchronizerRequest = new BaseDataSynchronizerRequest();                
                _result = _customerDataSynchronizer.SynchronizeData(customerDataSynchronizerRequest);

                var loanDataSynchronizerRequest = new BaseDataSynchronizerRequest();              
                _result = _loanDataSynchronizer.SynchronizeData(customerDataSynchronizerRequest);             


            }
            catch (Exception ex)
            {
            }

            _logger.LogInformation("CustomerPhaseOneOrchestrator successfull");

            return _result;
        }
    }

}
