using CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility;
using CoreValidatorExample.BusinessLayer.Data;
using CoreValidatorExample.BusinessLayer.Interfaces;
using CoreValidatorExample.BusinessLayer.ServiceDataOrchestrator.ServiceOrchestrator;
using CoreValidatorExample.DataAccessLayer.Data;
using Microsoft.Extensions.Logging;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManageFactoryGeneric
{
    public interface IChangeStateManagerFactory<T> where T : class
    {
        public IChangeStateManager<T> GetObjectInstance(int userId, int userCorporateUnitId, int itemId);
        
    }


}
