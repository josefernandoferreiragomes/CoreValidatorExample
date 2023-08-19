namespace CoreValidatorExample.APILibrary.ValidationChainOfResponsibilityConcept
{
    /// <summary>
    /// Validator interface for the Chain of Responsibility
    /// </summary>
    public interface IValidator
    {
        IValidator SetNext(IValidator validator);
        bool Validate(WorkflowContext context);
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
