using CodingChallengeApi.Core.Models;
using CodingChallengeApi.Data.Abstractions;

namespace CodingChallengeApi.Data.Implementations;
internal class EmployeeRepository : IEmployeeRepository
{
    public IList<Employee> GetEmployees()
    {
        return SimulatedDatabase.Employees.Values.ToList();
    }
    public Employee GetEmployee(int employeeId)
    {
        if (!SimulatedDatabase.Employees.ContainsKey(employeeId)) throw new ArgumentException("Employee id does not exist");
        return SimulatedDatabase.Employees[employeeId];
    }

    public int CreateEmployee(Employee employee)
    {
        int nextId = SimulatedDatabase.Employees.Keys.Max() + 1;
        employee.Id = nextId;
        bool success = SimulatedDatabase.Employees.TryAdd(nextId, employee);
        return success ? employee.Id : 0;
    }

    public void UpdateEmployee(int employeeId, Employee employee)
    {
        if (!SimulatedDatabase.Employees.ContainsKey(employeeId)) throw new ArgumentException("Employee id does not exist");
        SimulatedDatabase.Employees[employeeId] = employee;
    }
}
