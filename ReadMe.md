# Scope
	Create a validation engine for a WorkFlow engine

## Constraints
	Should be extendable
	To be used in different WorkFlows
	Validation rules might be the same in differnt flows
	Should be simple and easy to use by newcomers

## Sources
	https://dotnetchris.wordpress.com/2009/02/11/creating-a-generic-validation-framework/
	(has some bugs, corrected with check in number 2)

## Implementation alternatives

### Factory Change State Manager


### Chain of Responsibility Change State Manager


### StructureMap Change State Manager
In .NET Core (and specifically .NET 8), you can achieve similar behavior to StructureMap’s ForRequestedType<IValidator<Employee>>().TheDefaultIsConcreteType<EmployeeValidator>(); using the built-in dependency injection (DI) container by registering services in the IServiceCollection with the AddScoped, AddSingleton, or AddTransient methods, depending on the desired lifecycle of the service.

Here’s how you can map a default validator for a class, such as mapping IValidator<Employee> to EmployeeValidator, using the default .NET Core DI:

1. Registering the Validator in Startup.cs or Program.cs:
You can register the default validator for your class in Program.cs or wherever your services are configured.

csharp
Copy code
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register EmployeeValidator as the default implementation for IValidator<Employee>
        builder.Services.AddTransient<IValidator<Employee>, EmployeeValidator>();

        var app = builder.Build();

        app.Run();
    }
}
In this case, .AddTransient<IValidator<Employee>, EmployeeValidator>() specifies that whenever IValidator<Employee> is requested, the DI container will provide an instance of EmployeeValidator.

2. Creating the IValidator<T> Interface and Implementation:
If you haven't already, define your IValidator<T> interface and your EmployeeValidator class.

csharp
Copy code
public interface IValidator<T>
{
    bool Validate(T instance);
}

public class EmployeeValidator : IValidator<Employee>
{
    public bool Validate(Employee employee)
    {
        // Validation logic for Employee
        return employee != null && !string.IsNullOrEmpty(employee.Name);
    }
}
3. Consuming the Validator:
You can now inject the IValidator<Employee> in any of your classes and the default EmployeeValidator will be resolved by the DI container:

csharp
Copy code
public class SomeService
{
    private readonly IValidator<Employee> _employeeValidator;

    public SomeService(IValidator<Employee> employeeValidator)
    {
        _employeeValidator = employeeValidator;
    }

    public void DoSomething(Employee employee)
    {
        bool isValid = _employeeValidator.Validate(employee);

        if (isValid)
        {
            // Proceed with valid employee
        }
        else
        {
            // Handle invalid employee
        }
    }
}
4. Handling Multiple Validators for Different Types:
If you have multiple types and validators, you can register each one in a similar manner:

csharp
Copy code
builder.Services.AddTransient<IValidator<Employee>, EmployeeValidator>();
builder.Services.AddTransient<IValidator<Manager>, ManagerValidator>();
Each request for IValidator<Employee> will resolve to EmployeeValidator, and each request for IValidator<Manager> will resolve to ManagerValidator.

Summary:
To mimic the behavior of StructureMap in .NET Core's built-in DI, you use the AddTransient, AddScoped, or AddSingleton methods to map interface types (IValidator<T>) to their concrete implementations (EmployeeValidator).

Unit test:
To create an NUnit test project for testing your EmployeeValidator in .NET Core 8, follow these steps:

1. Create an NUnit Test Project
First, you need to create a new NUnit test project. You can do this using the .NET CLI:

bash
Copy code
dotnet new nunit -n EmployeeValidatorTests
This will create a new project named EmployeeValidatorTests with the NUnit framework as the test runner.

Alternatively, if you're using Visual Studio:

Go to File > New > Project.
Search for NUnit Test Project.
Select it and give your test project a name (e.g., EmployeeValidatorTests).
Click Create.
2. Install Required Packages
In case your main project (the one with EmployeeValidator) and your test project are not part of the same solution, you need to reference your main project in the test project.

From your test project directory, run:

bash
Copy code
dotnet add reference ../YourMainProject.csproj
Also, make sure your NUnit packages are up to date:

bash
Copy code
dotnet add package NUnit
dotnet add package Microsoft.NET.Test.Sdk
dotnet add package NUnit3TestAdapter
3. Create the Unit Test for EmployeeValidator
Inside the EmployeeValidatorTests project, you will have a default Tests.cs file or UnitTest1.cs. Replace its contents with a test for the EmployeeValidator.

Here’s an example of how you can write a test for your EmployeeValidator:

Employee Class (for reference)
csharp
Copy code
public class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }
}
EmployeeValidator Implementation (for reference)
csharp
Copy code
public class EmployeeValidator : IValidator<Employee>
{
    public bool Validate(Employee employee)
    {
        return employee != null && !string.IsNullOrEmpty(employee.Name);
    }
}
NUnit Test for EmployeeValidator
Create a new test file EmployeeValidatorTests.cs inside the EmployeeValidatorTests project.

csharp
Copy code
using NUnit.Framework;

namespace EmployeeValidatorTests
{
    public class EmployeeValidatorTests
    {
        private EmployeeValidator _validator;

        [SetUp]
        public void Setup()
        {
            // This method will run before each test
            _validator = new EmployeeValidator();
        }

        [Test]
        public void Validate_ShouldReturnTrue_WhenEmployeeIsValid()
        {
            // Arrange
            var employee = new Employee { Name = "John Doe", Age = 30 };

            // Act
            var result = _validator.Validate(employee);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Validate_ShouldReturnFalse_WhenEmployeeIsNull()
        {
            // Arrange
            Employee employee = null;

            // Act
            var result = _validator.Validate(employee);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_ShouldReturnFalse_WhenEmployeeNameIsEmpty()
        {
            // Arrange
            var employee = new Employee { Name = "", Age = 25 };

            // Act
            var result = _validator.Validate(employee);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_ShouldReturnFalse_WhenEmployeeNameIsNull()
        {
            // Arrange
            var employee = new Employee { Name = null, Age = 25 };

            // Act
            var result = _validator.Validate(employee);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
4. Run the NUnit Tests
To run your tests, you can use the .NET CLI or your IDE (like Visual Studio or JetBrains Rider).

Running Tests with the CLI:
Navigate to the directory where your test project is located and run:

bash
Copy code
dotnet test
This will build both your main project and the test project, and then run all the tests.

Running Tests in Visual Studio:
Build your solution.
Go to Test > Test Explorer.
Click Run All to run all the tests.
Explanation of the Tests
Test 1 (Validate_ShouldReturnTrue_WhenEmployeeIsValid):

This test ensures that the EmployeeValidator.Validate method returns true when the employee is valid (i.e., the Name property is not null or empty).
Test 2 (Validate_ShouldReturnFalse_WhenEmployeeIsNull):

This test ensures that the Validate method returns false when the employee is null.
Test 3 (Validate_ShouldReturnFalse_WhenEmployeeNameIsEmpty):

This test checks that the Validate method returns false when the Name is an empty string.
Test 4 (Validate_ShouldReturnFalse_WhenEmployeeNameIsNull):

This test verifies that the Validate method returns false when the Name is null.
5. Conclusion
By following these steps, you’ll have a working NUnit test project that tests your EmployeeValidator. You can extend the tests with additional cases as needed, but this is a good foundation to ensure your validator behaves correctly.





Unit test for the service
To create an NUnit test for the SomeService class, which depends on IValidator<Employee>, you will typically want to mock the IValidator<Employee> to control its behavior during tests. You can use a mocking framework like Moq for this purpose.

Steps to create an NUnit test for SomeService:
Install Moq (if not already installed).
Mock the IValidator<Employee> to simulate different validation scenarios.
Test the SomeService methods with various inputs.
1. Install Moq in Your Test Project
If you don’t have Moq installed in your test project, you can install it via the .NET CLI or through your NuGet package manager.

From the terminal (inside the test project directory):

bash
Copy code
dotnet add package Moq
Alternatively, in Visual Studio:

Right-click on the test project.
Select Manage NuGet Packages.
Search for Moq and install the latest version.
2. Unit Testing the SomeService Class
Let's assume that SomeService looks something like this:

csharp
Copy code
public class SomeService
{
    private readonly IValidator<Employee> _employeeValidator;

    public SomeService(IValidator<Employee> employeeValidator)
    {
        _employeeValidator = employeeValidator;
    }

    public bool ProcessEmployee(Employee employee)
    {
        bool isValid = _employeeValidator.Validate(employee);
        if (isValid)
        {
            // Process employee
            return true;  // Successful processing
        }
        else
        {
            // Handle invalid employee
            return false;  // Unsuccessful processing
        }
    }
}
Now, let’s create NUnit tests for SomeService.

3. Create the Test Class
Create a new test file called SomeServiceTests.cs in your test project:

csharp
Copy code
using NUnit.Framework;
using Moq;

namespace EmployeeValidatorTests
{
    [TestFixture]
    public class SomeServiceTests
    {
        private SomeService _someService;
        private Mock<IValidator<Employee>> _mockEmployeeValidator;

        [SetUp]
        public void Setup()
        {
            // Initialize the mock for IValidator<Employee>
            _mockEmployeeValidator = new Mock<IValidator<Employee>>();

            // Pass the mocked validator into the service
            _someService = new SomeService(_mockEmployeeValidator.Object);
        }

        [Test]
        public void ProcessEmployee_ShouldReturnTrue_WhenEmployeeIsValid()
        {
            // Arrange
            var employee = new Employee { Name = "John Doe", Age = 30 };

            // Setup mock to return true when Validate is called with the given employee
            _mockEmployeeValidator.Setup(v => v.Validate(employee)).Returns(true);

            // Act
            var result = _someService.ProcessEmployee(employee);

            // Assert
            Assert.IsTrue(result, "Expected ProcessEmployee to return true for valid employee.");
        }

        [Test]
        public void ProcessEmployee_ShouldReturnFalse_WhenEmployeeIsInvalid()
        {
            // Arrange
            var employee = new Employee { Name = "", Age = 30 }; // Invalid due to empty name

            // Setup mock to return false when Validate is called with the given employee
            _mockEmployeeValidator.Setup(v => v.Validate(employee)).Returns(false);

            // Act
            var result = _someService.ProcessEmployee(employee);

            // Assert
            Assert.IsFalse(result, "Expected ProcessEmployee to return false for invalid employee.");
        }

        [Test]
        public void ProcessEmployee_ShouldInvokeValidatorOnce()
        {
            // Arrange
            var employee = new Employee { Name = "Jane Doe", Age = 25 };

            // Act
            _someService.ProcessEmployee(employee);

            // Assert
            // Verify that the Validate method was called exactly once with the specified employee
            _mockEmployeeValidator.Verify(v => v.Validate(employee), Times.Once, 
                "Expected the validator's Validate method to be called exactly once.");
        }
    }
}
Explanation of the Tests
Test 1 (ProcessEmployee_ShouldReturnTrue_WhenEmployeeIsValid):

This test ensures that when a valid employee is passed into SomeService, the service's ProcessEmployee method returns true.
Mock Setup: The mock is configured to return true when Validate is called with a valid Employee object.
Test 2 (ProcessEmployee_ShouldReturnFalse_WhenEmployeeIsInvalid):

This test ensures that when an invalid employee (e.g., empty Name) is passed in, the service returns false.
Mock Setup: The mock is configured to return false when Validate is called with an invalid Employee object.
Test 3 (ProcessEmployee_ShouldInvokeValidatorOnce):

This test ensures that the Validate method is called exactly once for the given employee.
Mock Setup: No return value setup is needed here. Instead, we use Moq's Verify method to check how many times the Validate method was invoked.
4. Run the Tests
Just like with the previous tests, you can run the tests using the .NET CLI or an IDE.

Using the .NET CLI:
bash
Copy code
dotnet test
In Visual Studio:
Open the Test Explorer.
Click Run All to execute all the tests.
Conclusion
By using Moq to mock the IValidator<Employee>, you're able to isolate SomeService from the actual validation logic and test its behavior independently. This is a common practice in unit testing when your class depends on external services or interfaces.