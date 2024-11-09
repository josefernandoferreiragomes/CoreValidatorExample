# Scope
Create a validation mechanism for a WorkFlow engine
Create service orchestrator

## Constraints
Should be extendable
To be used in different WorkFlows
Validation rules might be the same in differnt flows	

## Steps
Create a solution, including business layer, and Web API, and unit tests
	
Investigate and create 3 simplified PoCs, one for each alternative.

## Sources
	https://dotnetchris.wordpress.com/2009/02/11/creating-a-generic-validation-framework/
	(has some bugs, corrected with check in number 2)

	(...)

## Implementation alternatives

#### Factory Change State Manager

#### Chain of Responsibility Change State Manager

#### StructureMap Change State Manager (TOBE)

# Detailed description:

# Change State Manager Factory

This project demonstrates the implementation of the **Factory Design Pattern** for managing the instantiation of different state managers related to various business entities such as `Appraisal`, `Proposal`, and `Decision`. The `ChangeStateManagerFactory` provides an extensible and dynamic way to create instances of different state management classes based on the type of entity being processed.

## Features

### 1. Factory Design Pattern
The core feature of this implementation is the **Factory Design Pattern**, which abstracts the process of creating objects. The `ChangeStateManagerFactory` dynamically instantiates the appropriate state manager class based on the business entity type.

### 2. Support for Multiple Entities
The `ChangeStateManagerFactory` is designed to handle the instantiation of state managers for various business entities, such as:
- **Appraisal**: Instantiates `AppraisalChangeStateManager` for managing state transitions related to appraisals.
- **Proposal**: Instantiates `ProposalChangeStateManager` to handle proposal-specific state changes.
- **Decision**: Instantiates `DecisionChangeStateManager` to manage state changes for decisions.

### 3. Generic and Type-Safe
The factory implementation is generic and type-safe. By leveraging C#'s generic capabilities, the factory ensures that only valid types (such as `Appraisal`, `Proposal`, `Decision`) are used when creating state managers, thus reducing runtime errors.

### 4. Extensible for New Entities
New entities and state managers can easily be added without changing the existing codebase. This makes the system highly extensible, enabling seamless support for additional business types in the future.

### 5. Centralized Object Creation
The factory centralizes the logic of object creation, keeping the business logic separate from the instantiation process. This promotes cleaner, more maintainable code, especially when working with multiple state managers.

## Key Classes

### `ChangeStateManagerFactory<T>`
This is the main factory class that handles the creation of different state manager instances. It uses the type `T` to determine which state manager should be instantiated. It provides the following key method:

- `GetObjectInstance(int userId, int userCorporateUnitId, int itemId)`: This method takes user-specific data as arguments and returns the appropriate `IChangeStateManager<T>` instance.

### `AppraisalChangeStateManager`
A state manager class that manages the state transitions for the `Appraisal` entity. This class implements the `IChangeStateManager<Appraisal>` interface.

### `ProposalChangeStateManager`
A state manager class responsible for handling state transitions for `Proposal` entities, implementing the `IChangeStateManager<Proposal>` interface.

### `DecisionChangeStateManager`
A state manager class that handles the state transitions for `Decision` entities, implementing the `IChangeStateManager<Decision>` interface.

## Adding New State Managers
If you need to add support for a new entity and its corresponding state manager, follow these steps:

Create a new entity class: For example, NewEntity.

Create a new state manager class: Implement the IChangeStateManager<NewEntity> interface and define the state transition logic in this new class.

Modify the factory: Add a new case in the ChangeStateManagerFactory's GetObjectInstance method to handle the instantiation of the new state manager.

## Extensibility

This factory pattern allows you to easily add new entities and their respective state managers without modifying the core system significantly. Simply add a new state manager, register it in the factory, and the rest of the system will work seamlessly with the new entity.

## Unit Testing
The ChangeStateManagerFactory and the state managers are unit-testable. You can mock different IChangeStateManager implementations and test the behavior of the factory.

# Change State Manager Chain of Responsibility
This project demonstrates the implementation of the Chain of Responsibility design pattern applied to the state management of various business entities such as Appraisal, Proposal, and Decision. This pattern allows for a flexible, decoupled, and scalable way to handle different state transitions based on specific validation criteria.

## Features:
## Chain of Responsibility Pattern
The core feature of this implementation is the Chain of Responsibility design pattern, which enables the sequential processing of state validation through a chain of handlers. Each handler performs its validation, and if it cannot handle the state, it passes it on to the next handler in the chain.

## Support for Multiple Entities
This implementation is flexible enough to support various business entities, such as:

**Appraisal**: Handles validation and state changes specific to appraisal management.
**Proposal**: Manages proposal-related state changes through a chain of validators.
**Decision**: Manages the state transition for decision entities with appropriate validations.

## Extendable and Configurable
The ChangeStateManagerChainOfResponsibility is designed to be easily extended. New validators or business logic can be added to the chain without modifying existing code. This is achieved through:

Pluggable Handlers: New state managers or validation handlers can be introduced by simply implementing the IChangeStateValidatorHandler<T> interface.
Configurable Chains: Chains can be configured based on different business rules or context, providing flexibility for different scenarios.

## Separation of Concerns
Each responsibility in the validation chain is separated into different classes, ensuring that each handler focuses on a specific piece of the validation logic. This makes the system more maintainable and readable.

## Unit-Testable
The implementation supports unit testing by allowing individual handlers to be tested in isolation. Each handler in the chain can be tested to ensure that it correctly processes its validation logic before passing the responsibility to the next handler.

## Key Classes

IChangeStateValidatorHandler<T>

This is the core interface that defines the contract for each handler in the chain. It provides:

A method SetNext(IChangeStateValidatorHandler<T> handler) to set the next handler in the chain.
A method Handle(T entity) to perform validation and state management for the entity.

AppraisalChangeStateManager

This class implements the IChangeStateValidatorHandler<T> interface for the Appraisal entity. It handles validation and state transitions specific to appraisals.

ProposalChangeStateManager

Similar to the AppraisalChangeStateManager, this class implements the IChangeStateValidatorHandler<T> interface for the Proposal entity.

DecisionChangeStateManager

This class also implements the IChangeStateValidatorHandler<T> interface and is responsible for handling state transitions and validation logic for decisions.

## Extending the Chain

To extend the chain with a new state manager:

Create a new class that implements IChangeStateValidatorHandler<T>.
Define the validation and state logic in the Handle(T entity) method.
Add the new handler to the chain using SetNext().

### Additional notes
Added docker support (docker file was generated automatically)