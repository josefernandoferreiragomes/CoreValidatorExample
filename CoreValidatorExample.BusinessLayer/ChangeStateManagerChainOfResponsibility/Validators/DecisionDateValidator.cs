﻿using CoreValidatorExample.BusinessLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.BusinessLayer.ChangeStateManagerChainOfResponsibility
{
    // DecisionDateValidator.cs
    public class DecisionDateValidator : IChangeStateValidatorHandler<Decision>
    {
        private IChangeStateValidatorHandler<Decision> _nextHandler;

        public void SetNext(IChangeStateValidatorHandler<Decision> nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public void Handle(Decision decision)
        {
            if (decision.DecisionDate > DateTime.Now)
            {
                throw new InvalidOperationException("Decision date cannot be in the future.");
            }

            _nextHandler?.Handle(decision);
        }
    }

}
