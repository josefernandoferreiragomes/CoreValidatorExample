using CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.Interfaces;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator;
using CoreValidatorExample.DataAccessLayer.Data;
using Microsoft.Extensions.Logging;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class ChangeStateManagerFactory<T> where T : class
    {
        public ILogger<LoanPhaseOneOrchestrator> _logger {get; set;}
        public IGenericRepository<Loan> _loanRepository {get; set;}
        public IGenericRepository<Collateral> _collateralRepository {get; set;}
        public IGenericRepository<Asset> _assetRepository { get; set; }
        public T? ObjectInstance { get; set; }

        public ChangeStateManagerFactory(ILogger<LoanPhaseOneOrchestrator> logger, IGenericRepository<Loan> loanRepository, IGenericRepository<Collateral> collateralRepository, IGenericRepository<Asset> assetRepository)
        {
            _logger = logger;
            _loanRepository = loanRepository;
            _collateralRepository = collateralRepository;
            _assetRepository = assetRepository;
        }
        public IChangeStateManager<T> GetObjectInstance(int userId, int userCorporateUnitId, int itemId)
        {
            IChangeStateManager<T> objInstance;

            // Check the type of T and instantiate the appropriate manager
            switch (typeof(T).Name)
            {
                case nameof(Appraisal):
                    objInstance = (IChangeStateManager<T>)Activator.CreateInstance(
                        typeof(AppraisalChangeStateManager<>).MakeGenericType(typeof(T)), userId, userCorporateUnitId, itemId, ObjectInstance, _logger, _loanRepository, _collateralRepository, _assetRepository
                    );
                    break;

                case nameof(Proposal):
                    objInstance = (IChangeStateManager<T>)Activator.CreateInstance(
                        typeof(ProposalChangeStateManager<>).MakeGenericType(typeof(T)), userId, userCorporateUnitId, itemId, ObjectInstance, _logger, _loanRepository, _collateralRepository, _assetRepository
                    );
                    break;

                case nameof(Decision):
                    objInstance = (IChangeStateManager<T>)Activator.CreateInstance(
                        typeof(DecisionChangeStateManager<>).MakeGenericType(typeof(T)), userId, userCorporateUnitId, itemId, ObjectInstance, _logger, _loanRepository, _collateralRepository, _assetRepository
                    );
                    break;

                default:
                    throw new ArgumentException($"No matching ChangeStateManager found for {typeof(T).Name}");
            }

            return objInstance;
        }
    }


}
