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
        public IGenericRepository<Loan> _loanRepository;
        public IGenericRepository<Collateral> _collateralRepository;
        public IGenericRepository<Asset> _assetRepository;
        
        WebAPIClassReference _externalApiService;        

        public LoanPhaseOneOrchestrator(BaseOrchestratorRequest request, ILogger<LoanPhaseOneOrchestrator> _logger, IGenericRepository<Loan> loanRepository, IGenericRepository<Collateral> collateralRepository, IGenericRepository<Asset> assetRepository) 
            : base (request, _logger)
        {
            _loanRepository = loanRepository;
            _collateralRepository = collateralRepository;
            _assetRepository = assetRepository;

        }        


        public override async Task<BaseServiceDataOrchestratorResult> Orchestrate()
        {
            try
            {

                var loans = await _loanRepository.GetAllAsync();
                var collaterals = await _collateralRepository.GetAllAsync();

                var loanDataSynchronizerRequest = new BaseDataSynchronizerRequest();
                var loanDataSynchronizer = new LoanDataSynchronizer(loanDataSynchronizerRequest, _logger, _loanRepository);
                _result = loanDataSynchronizer.SynchronizeData();

                var collateralDataSynchronizerRequest = new BaseDataSynchronizerRequest();
                var collateralDataSynchronizer = new CollateralDataSynchronizer(collateralDataSynchronizerRequest, _logger, _collateralRepository);
                _result = collateralDataSynchronizer.SynchronizeData();

                var assetDataSynchronizerRequest = new BaseDataSynchronizerRequest();
                var assetDataSynchronizer = new AssetDataSynchronizer(assetDataSynchronizerRequest, _logger, _assetRepository);
                _result = assetDataSynchronizer.SynchronizeData();


            }
            catch (Exception ex)
            {
            }

            _logger.LogInformation("LoanPhaseOneOrchestrator successfull");

            return _result;
        }
    }

}
