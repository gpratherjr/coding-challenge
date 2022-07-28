using CodingChallengeApi.Core.Models;
using CodingChallengeApi.Service.Abstractions;

namespace CodingChallengeApi.Service.Implementations;
internal class DeductionCalculator : IDeductionCalculator
{
    private const int NumberOfPayPeriods = 26;
    private const decimal Discount = .9M;
    public decimal CalculateDeductions(Employee employee)
    {
        decimal employeeDeduction = CalculatePerPersonBenefitDeduction(employee);
        decimal dependentDeductions = employee.Dependents
            .Select(d => CalculatePerPersonBenefitDeduction(d))
            .Sum();
        return employeeDeduction + dependentDeductions;
    }

    private static decimal CalculatePerPersonBenefitDeduction(Person person)
    {
        int baseDeduction = person is Employee ? 1000 : 500;
        decimal discounted = person.FirstName.StartsWith("A", StringComparison.CurrentCultureIgnoreCase) ? Discount : 1;
        decimal totalDeduction = baseDeduction * discounted / NumberOfPayPeriods;
        return Math.Round(totalDeduction, 2, MidpointRounding.AwayFromZero);
    }
}
