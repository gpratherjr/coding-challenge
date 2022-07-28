using CodingChallengeApi.Core.Models;

namespace CodingChallengeApi.Service.Abstractions;
public interface IEmployeeService
{
    int CreateEmployee(Employee employee);
    Employee GetEmployee(int employeeId);
    IList<Employee> GetEmployees();
    void UpdateEmployee(int employeeId, Employee employee);
}
