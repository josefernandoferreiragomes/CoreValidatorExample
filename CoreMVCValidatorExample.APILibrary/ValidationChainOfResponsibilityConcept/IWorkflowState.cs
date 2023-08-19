namespace CoreValidatorExample.APILibrary.ValidationChainOfResponsibilityConcept
{
    /// <summary>
    /// State interface for the State pattern
    /// </summary>
    public interface IWorkflowState
    {
        void HandleTransition(WorkflowContext context);
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
