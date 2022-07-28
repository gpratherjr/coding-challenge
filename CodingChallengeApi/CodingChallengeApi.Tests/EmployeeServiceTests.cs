using CodingChallengeApi.Core.Models;
using CodingChallengeApi.Data.Abstractions;
using CodingChallengeApi.Service.Abstractions;
using CodingChallengeApi.Service.Implementations;
using FluentAssertions;
using FluentAssertions.Execution;
using NSubstitute;

namespace CodingChallengeApi.Tests;

[TestFixture]
public class EmployeeServiceTests
{
    private readonly IEmployeeRepository _employeeRepository = Substitute.For<IEmployeeRepository>();
    private readonly IDeductionCalculator _deductionCalculator = Substitute.For<IDeductionCalculator>();
    private EmployeeService _sut;
    private const decimal _deduction = 57;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _employeeRepository.GetEmployees().Returns(new List<Employee> { 
            new Employee { Id = 1, FirstName = "test", LastName = "test" },
            new Employee { Id = 2, FirstName = "test", LastName = "test" }
        });
        _deductionCalculator.CalculateDeductions(Arg.Any<Employee>()).Returns(_deduction);
        _sut = new EmployeeService(_employeeRepository, _deductionCalculator);
    }

    [SetUp]
    public void Setup()
    {
        _deductionCalculator.ClearReceivedCalls();
    }

    [Test]
    public void EmployeeService_GetEmployees_Returns_With_Deductions()
    {
        IList<Employee> employees = _sut.GetEmployees();
        using (new AssertionScope())
        {
            employees.Should().HaveCount(2);
            _deductionCalculator.Received(2).CalculateDeductions(Arg.Any<Employee>());
            employees.Should().OnlyContain(e => e.Salary == Employee.BaseSalary - _deduction);
        }
    }

    [Test]
    public void EmployeeService_GetEmployee_Returns_With_Deductions()
    {
        Employee employee = _sut.GetEmployee(1);
        using (new AssertionScope())
        {
            _deductionCalculator.Received(1).CalculateDeductions(Arg.Any<Employee>());
            employee.Salary.Should().Be(Employee.BaseSalary - _deduction);
        }
    }
}
