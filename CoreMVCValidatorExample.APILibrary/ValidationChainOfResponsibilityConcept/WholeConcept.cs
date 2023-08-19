using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreValidatorExample.APILibrary.ValidationChainOfResponsibilityConcept
{

    // Concrete validator for a specific validation rule
    public class ValidationRuleValidator : IValidator
    {
        private IValidator _nextValidator;

        public IValidator SetNext(IValidator validator)
        {
            _nextValidator = validator;
            return validator;
        }

        public bool Validate(WorkflowContext context)
        {
            // Perform validation based on the rule for this state
            // Return false if validation fails, otherwise continue to next validator
            if (true/* Validation condition not met */)
            {
                return false;
            }

            return _nextValidator?.Validate(context) ?? true;
        }
    }

    // Concrete state with associated validation
    public class SomeWorkflowState : IWorkflowState
    {
        private IValidator _validatorChain;

        public SomeWorkflowState(IValidator validatorChain)
        {
            _validatorChain = validatorChain;
        }

        public void HandleTransition(WorkflowContext context)
        {
            // Perform actions for transitioning to this state
            // Call validator chain to perform state-specific validation
            if (_validatorChain.Validate(context))
            {
                // Proceed with state transition
            }
            else
            {
                // Handle validation failure
            }
        }
    }

    //// Workflow context containing relevant data
    //public class WorkflowContext
    //{
    //    // Relevant data for validation and state handling
    //}

    //// Usage
    //class WorkflowEngine
    //{
    //    static void Main()
    //    {
    //        // Create validator chain for a specific state
    //        IValidator validatorChain = new ValidationRuleValidator()
    //            .SetNext(new AnotherValidationRuleValidator())
    //            .SetNext(new YetAnotherValidationRuleValidator());

    //        // Create state with associated validator chain
    //        IWorkflowState state = new SomeWorkflowState(validatorChain);

    //        WorkflowContext context = new WorkflowContext();
    //        state.HandleTransition(context);
    //    }
    //}
}
