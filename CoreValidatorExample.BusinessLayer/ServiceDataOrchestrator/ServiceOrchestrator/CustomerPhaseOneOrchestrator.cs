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
        public IGenericRepository<Loan> _loanRepository;
        public IGenericRepository<Customer> _customerRepository;        
        
        WebAPIClassReference _externalApiService;        

        public CustomerPhaseOneOrchestrator(BaseOrchestratorRequest request, ILogger<CustomerPhaseOneOrchestrator> logger, IGenericRepository<Customer> customerRepository, IGenericRepository<Loan> loanRepository) 
            : base (request, logger)
        {
            _loanRepository = loanRepository;
            _customerRepository = customerRepository;            

        }        


        public override async Task<BaseServiceDataOrchestratorResult> Orchestrate()
        {
            try
            {

                var loans = await _loanRepository.GetAllAsync();
                var customers = await _customerRepository.GetAllAsync();

                var customerDataSynchronizerRequest = new BaseDataSynchronizerRequest();
                var customerDataSynchronizer = new CustomerDataSynchronizer(customerDataSynchronizerRequest, _logger, _customerRepository);
                _result = customerDataSynchronizer.SynchronizeData();

                var loanDataSynchronizerRequest = new BaseDataSynchronizerRequest();
                var loanDataSynchronizer = new LoanDataSynchronizer(loanDataSynchronizerRequest, _logger, _loanRepository);
                _result = loanDataSynchronizer.SynchronizeData();             


            }
            catch (Exception ex)
            {
            }

            _logger.LogInformation("CustomerPhaseOneOrchestrator successfull");

            return _result;
        }
    }

}
