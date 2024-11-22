using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator;
using CoreValidatorExample.DataAccessLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public class ChangeStateManagerFactory<T> : IChangeStateManagerFactory<T> where T : class
    {
        private readonly IServiceProvider _serviceProvider;

        public ILogger _logger {get; set;}
        
        public T? ObjectInstance { get; set; }

        public ChangeStateManagerFactory(ILogger logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }
        public IChangeStateManager<T> GetObjectInstance(int userId, int userCorporateUnitId, int itemId, T obj)
        {
            IChangeStateManager<T> objInstance;

            // Check the type of T and instantiate the appropriate manager
            switch (typeof(T).Name)
            {
                case nameof(Appraisal):
                    objInstance = (IChangeStateManager<T>)Activator.CreateInstance(
                        typeof(AppraisalChangeStateManager<>)
                            .MakeGenericType(
                                typeof(T)), 
                                userId, 
                                userCorporateUnitId, 
                                itemId,
                                obj, 
                                _logger
                    );                    
                    //objInstance = _serviceProvider.GetService<IChangeStateManager<T>>();
                    break;

                case nameof(Proposal):
                    objInstance = (IChangeStateManager<T>)Activator.CreateInstance(
                        typeof(ProposalChangeStateManager<>).MakeGenericType(typeof(T)), userId, userCorporateUnitId, itemId, ObjectInstance, _logger
                    );
                    break;

                case nameof(Decision):
                    objInstance = (IChangeStateManager<T>)Activator.CreateInstance(
                        typeof(DecisionChangeStateManager<>).MakeGenericType(typeof(T)), userId, userCorporateUnitId, itemId, ObjectInstance, _logger, _serviceProvider.GetService<IBaseOrchestrator>()
                    );
                    break;

                default:
                    throw new ArgumentException($"No matching ChangeStateManager found for {typeof(T).Name}");
            }

            return objInstance;
        }
    }


}
