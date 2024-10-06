## Business need / Functional Requirement:

synchronize two databases

the remote database is accessed through an external api

each entity needs multiple api calls to be synchronized

synchronizations might be partial or total

## NFR

logs need to be collected from each call, sent to rabbitmq and stored in MongoDB

data is first fetched from local database, then sent to remote api

different entities need different synchronizer classes

An orchestrator will have multiple synchronizers

IoC

multithreading

automapper

asynchronous

online

UnitTest

IntegrationTest

### Implementatino

To be implemented...

### AI advice:
For a demonstration application that synchronizes data between a local database and a legacy database through a set of API calls, you should consider the following aspects:

1. Architecture Design

1. Orchestrator Pattern: Use this pattern to manage the workflow of fetching data, invoking APIs, and storing results.
Service Layer: Encapsulate business logic in services to keep your code modular and maintainable.
Repository Pattern: Abstract data access logic to interact with your databases.

1. 2. Data Flow
Get From Local: Fetch loan and collateral information from the local database.
Map data: map local data to the the request object 
invoke remote api: Invoke the necessary APIs to process or enrich the data and send .
Update local: Store the updated state back into the local database and log the API calls.

1. 3. Error Handling
Implement robust error handling to manage failures in API calls or database operations.
Use retry mechanisms for transient errors and log all errors for debugging.

1. 4. Logging and Monitoring
Service Call Logs: Log each API call with details like request, response, and status.
Application Logs: Track the application’s workflow and any errors encountered.

1. 5. Security
Ensure secure communication with APIs using HTTPS.
Implement authentication and authorization for API calls.
Protect sensitive data in transit and at rest.

1. 6. Performance
Optimize database queries to minimize latency.
Use asynchronous programming to handle API calls without blocking the main thread.

1. 7. Scalability
Design the application to handle increased load, such as more frequent API calls or larger data sets.
Consider using a message queue for handling high volumes of data synchronization tasks.

1. 8. Testing
Write unit tests for individual components like services and repositories.
Implement integration tests to verify the end-to-end workflow.
Example Implementation Steps

1. Set Up the Project:

1. Create a new .NET project.
Add necessary packages for database access (e.g., Entity Framework) and HTTP client for API calls.

1. Define Models:
Create models for loan and collateral information.

1. Implement Repositories:
Create repository classes for accessing the local database.

1. Create Services:
Implement services to handle business logic, including fetching data, invoking APIs, and storing results.

1. Orchestrator:
Develop an orchestrator class to manage the workflow of data synchronization.

1. Logging:
Set up logging to capture service call details and application workflow.

### Orchestrator snippet:
```csharp
public class DataSyncOrchestrator
{
    private readonly ILoanRepository _loanRepository;
    private readonly ICollateralRepository _collateralRepository;
    private readonly IApiService _apiService;
    private readonly ILogger<DataSyncOrchestrator> _logger;

    public DataSyncOrchestrator(
        ILoanRepository loanRepository,
        ICollateralRepository collateralRepository,
        IApiService apiService,
        ILogger<DataSyncOrchestrator> logger)
    {
        _loanRepository = loanRepository;
        _collateralRepository = collateralRepository;
        _apiService = apiService;
        _logger = logger;
    }

    public async Task SynchronizeDataAsync()
    {
        var loans = await _loanRepository.GetLoansAsync();
        var collaterals = await _collateralRepository.GetCollateralsAsync();

        foreach (var loan in loans)
        {
            var apiResponse = await _apiService.InvokeApiAsync(loan);
            if (apiResponse.IsSuccess)
            {
                await _loanRepository.UpdateLoanAsync(loan, apiResponse.Data);
                _logger.LogInformation("Loan {LoanId} updated successfully.", loan.Id);
            }
            else
            {
                _logger.LogError("Failed to update loan {LoanId}.", loan.Id);
            }
        }

        // Similar logic for collaterals...
    }
}

```