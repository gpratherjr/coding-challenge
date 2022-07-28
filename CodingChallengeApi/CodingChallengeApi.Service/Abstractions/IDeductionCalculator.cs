using CodingChallengeApi.Core.Models;

namespace CodingChallengeApi.Service.Abstractions;
public interface IDeductionCalculator
{
    decimal CalculateDeductions(Employee employee);
}
