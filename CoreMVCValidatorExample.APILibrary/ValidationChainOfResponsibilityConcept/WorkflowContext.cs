namespace CoreValidatorExample.BusinessLayer.ValidationChainOfResponsibilityConcept
{
    // Workflow context containing relevant data
    public class WorkflowContext
    {
        // Relevant data for validation and state handling
    }

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
