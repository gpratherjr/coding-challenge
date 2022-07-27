using CodingChallengeApi.Core.Models;
using CodingChallengeApi.Data.Abstractions;

namespace CodingChallengeApi.Data.Implementations;
internal class EmployeeRepository : IEmployeeRepository
{
    public IList<Employee> GetEmployees()
    {
        return SimulatedDatabase.Employees.Values.ToList();
    }
}
