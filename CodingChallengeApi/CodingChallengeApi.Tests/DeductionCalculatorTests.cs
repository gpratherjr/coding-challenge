using CodingChallengeApi.Core.Models;
using CodingChallengeApi.Service.Implementations;
using FluentAssertions;

namespace CodingChallengeApi.Tests;

[TestFixture]
public class DeductionCalculatorTests
{
    private readonly DeductionCalculator _sut = new();

    [Test]
    public void Deduction_Correctly_Calculated_For_Single_Employee()
    {
        Employee data = new()
        {
            FirstName = "test",
            LastName = "test"
        };
        
        decimal result = _sut.CalculateDeductions(data);
        result.Should().BeApproximately(1000 / 26M, .01M);
    }

    [Test]
    public void Deduction_Correctly_Calculated_For_Single_Employee_With_Discount()
    {
        Employee data = new()
        {
            FirstName = "atest",
            LastName = "Test"
        };

        decimal result = _sut.CalculateDeductions(data);
        result.Should().BeApproximately(1000 / 26M * .9M, .01M);
    }

    [Test]
    public void Deduction_Correctly_Calculated_For_Employee_With_Dependent_No_Discount()
    {
        Employee data = new()
        {
            FirstName = "test",
            LastName = "Test",
            Dependents = new[] { new Person { FirstName = "spouse", LastName = "test"} }
        };

        decimal result = _sut.CalculateDeductions(data);
        result.Should().BeApproximately(1500 / 26M, .01M);
    }

    [Test]
    public void Deduction_Correctly_Calculated_For_Employee_With_Dependent_Both_Discount()
    {
        Employee data = new()
        {
            FirstName = "atest",
            LastName = "Test",
            Dependents = new[] { new Person { FirstName = "aspouse", LastName = "test" } }
        };

        decimal result = _sut.CalculateDeductions(data);
        result.Should().BeApproximately(1500 / 26M * .9M, .01M);
    }

    [Test]
    public void Deduction_Correctly_Calculated_For_Employee_With_Dependent_One_Discount()
    {
        Employee data = new()
        {
            FirstName = "atest",
            LastName = "Test",
            Dependents = new[] { new Person { FirstName = "spouse", LastName = "test" } }
        };

        decimal result = _sut.CalculateDeductions(data);
        result.Should().BeApproximately((1000 * .9M + 500) / 26, .01M);
    }
}