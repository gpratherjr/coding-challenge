using CodingChallengeApi.Core.Models;

namespace CodingChallengeApi.Service.Abstractions;
public interface IEmployeeService
{
    IList<Employee> GetEmployees();
}
