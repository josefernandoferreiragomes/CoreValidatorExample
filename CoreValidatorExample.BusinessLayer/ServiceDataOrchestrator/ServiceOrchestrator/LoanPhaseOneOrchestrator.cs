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
    public class LoanPhaseOneOrchestrator : BaseOrchestrator
    {
        private readonly IEnumerable<IBaseDataSynchronizer> _dataSynchronizers;
        public IGenericRepository<Loan> _loanRepository;
        public IGenericRepository<Collateral> _collateralRepository;
        public IGenericRepository<Asset> _assetRepository;

        public IBaseDataSynchronizer _customerDataSynchronizer;
        public IBaseDataSynchronizer _collateralDataSynchronizer;
        public IBaseDataSynchronizer _assetDataSynchronizer;

        WebAPIClassReference _externalApiService;        

        public LoanPhaseOneOrchestrator(ILogger<LoanPhaseOneOrchestrator> _logger, IEnumerable<IBaseDataSynchronizer> dataSynchronizers, IGenericRepository<Loan> loanRepository, IGenericRepository<Collateral> collateralRepository, IGenericRepository<Asset> assetRepository) 
            : base (_logger)
        {
            _dataSynchronizers = dataSynchronizers;
            _loanRepository = loanRepository;
            _collateralRepository = collateralRepository;
            _assetRepository = assetRepository;
            this._collateralDataSynchronizer = _dataSynchronizers.OfType<CollateralDataSynchronizer>().FirstOrDefault();
            this._customerDataSynchronizer = _dataSynchronizers.OfType<CustomerDataSynchronizer>().FirstOrDefault();
            this._assetDataSynchronizer = _dataSynchronizers.OfType<AssetDataSynchronizer>().FirstOrDefault();
        }        


        public override async Task<BaseServiceDataOrchestratorResult> Orchestrate(BaseOrchestratorRequest baseOrchestratorRequest)
        {
            try
            {

                var loans = await _loanRepository.GetAllAsync();
                var collaterals = await _collateralRepository.GetAllAsync();

                //TODO for all, sync//TODO for all, sync
                var loanDataSynchronizerRequest = new BaseDataSynchronizerRequest();
                _result = _collateralDataSynchronizer.SynchronizeData(loanDataSynchronizerRequest);
                

                var collateralDataSynchronizerRequest = new BaseDataSynchronizerRequest();                
                _result = _collateralDataSynchronizer.SynchronizeData(collateralDataSynchronizerRequest);

                var assetDataSynchronizerRequest = new BaseDataSynchronizerRequest();           
                _result = _assetDataSynchronizer.SynchronizeData(assetDataSynchronizerRequest);


            }
            catch (Exception ex)
            {
            }

            _logger.LogInformation("LoanPhaseOneOrchestrator successfull");

            return _result;
        }
    }

}
