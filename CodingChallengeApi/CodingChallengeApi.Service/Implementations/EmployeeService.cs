using CodingChallengeApi.Core.Models;
using CodingChallengeApi.Data.Abstractions;
using CodingChallengeApi.Service.Abstractions;

namespace CodingChallengeApi.Service.Implementations;
internal class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IDeductionCalculator _deductionCalculator;

    public EmployeeService(IEmployeeRepository employeeRepository, IDeductionCalculator deductionCalculator)
    {
        _employeeRepository = employeeRepository;
        _deductionCalculator = deductionCalculator;
    }

    public IList<Employee> GetEmployees()
    {
        IList<Employee> employees = _employeeRepository.GetEmployees();
        foreach(Employee employee in employees)
        {
            employee.Deductions = _deductionCalculator.CalculateDeductions(employee);
        }
        return employees;
    }

    public Employee GetEmployee(int employeeId)
    {
        Employee employee = _employeeRepository.GetEmployee(employeeId);
        employee.Deductions = _deductionCalculator.CalculateDeductions(employee);
        return employee;
    }

    public int CreateEmployee(Employee employee)
    {
        return _employeeRepository.CreateEmployee(employee);
    }

    public void UpdateEmployee(int employeeId,Employee employee)
    {
        _employeeRepository.UpdateEmployee(employeeId, employee);
    }
}
