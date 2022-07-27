using CodingChallengeApi.Core.Models;
using CodingChallengeApi.Service.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallengeApi.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult GetEmployees()
    {
        IList<Employee> employees = _employeeService.GetEmployees();
        return Ok(employees);
    }

    [HttpGet("{employeeId}")]
    public IActionResult GetEmployee(int employeeId)
    {
        return Ok();
    }
}
