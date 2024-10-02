using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreValidatorExample.BusinessLayer.ValidationChainOfResponsibilityConcept;

namespace CoreValidatorExample.ApiLibrary.Tests.Unit
{
    // Usage
    class ChainOfResponsibilityConceptTester
    {
        [Test]
        public void TestChainOfResponsibility()
        {
            // Create validator chain for a specific state
            IValidator validatorChain = new ValidationRuleValidator()
                //.SetNext(new AnotherValidationRuleValidator())
                //.SetNext(new YetAnotherValidationRuleValidator())
                ;

            // Create state with associated validator chain
            IWorkflowState state = new SomeWorkflowState(validatorChain);

            WorkflowContext context = new WorkflowContext();
            state.HandleTransition(context);
        }

        //InTreatment_VerifyIfFINEWasPublishedValidator
        [Test]
        public void TestChainOfResponsibilityApplied()
        {
            // Create validator chain for a specific state
            IValidator validatorChain = new InTreatment_FlexibilityRulesValidator()
                .SetNext(new InTreatment_VerifyIfFINEWasPublishedValidator())
                //.SetNext(new YetAnotherValidationRuleValidator())
                ;

            // Create state with associated validator chain
            IWorkflowState state = new InTreatment(validatorChain);

            WorkflowContext context = new WorkflowContext();
            state.HandleTransition(context);
        }
    }
}
