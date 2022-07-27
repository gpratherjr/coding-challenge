using CodingChallengeApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallengeApi.Data.Abstractions;
public interface IEmployeeRepository
{
    int CreateEmployee(Employee employee);
    IList<Employee> GetEmployees();
    void UpdateEmployee(int employeeId, Employee employee);
}
