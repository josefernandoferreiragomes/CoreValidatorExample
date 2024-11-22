using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.DataSynchronizers;
using Microsoft.Extensions.Logging;

namespace CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator
{
    public class CustomerPhaseOneOrchestrator : BaseOrchestrator
    {
        private readonly IEnumerable<IBaseDataSynchronizer> _dataSynchronizers;
        public IBaseDataSynchronizer _customerDataSynchronizer;
        public IBaseDataSynchronizer _loanDataSynchronizer;
        ILogger<CustomerPhaseOneOrchestrator> _logger;
        public int _customerId;
       
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
