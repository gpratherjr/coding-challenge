using CodingChallengeApi.Core.Models;
using CodingChallengeApi.Data.Abstractions;
using CodingChallengeApi.Service.Abstractions;

namespace CodingChallengeApi.Service.Implementations;
internal class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public IList<Employee> GetEmployees()
    {
        return _employeeRepository.GetEmployees();
    }
}
