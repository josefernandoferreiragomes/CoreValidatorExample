using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreValidatorExample.BusinessLayer.Models;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // IChangeStateValidatorHandler.cs
    public interface IChangeStateValidatorHandler<T>
    {
        void SetNext(IChangeStateValidatorHandler<T> nextHandler);
        void Handle(T entity);
    }

}
