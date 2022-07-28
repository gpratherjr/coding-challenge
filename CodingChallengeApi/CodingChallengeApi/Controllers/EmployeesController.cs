using CodingChallengeApi.Core.Models;
using CodingChallengeApi.Service.Abstractions;
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
    [ProducesResponseType(typeof(IList<Employee>), StatusCodes.Status200OK)]
    public IActionResult GetEmployees()
    {
        IList<Employee> employees = _employeeService.GetEmployees();
        return Ok(GetResponse(employees));
    }

    [HttpGet("{employeeId}")]
    public IActionResult GetEmployee(int employeeId)
    {
        Employee employee = _employeeService.GetEmployee(employeeId);
        return Ok(GetResponse(employee));
    }

    [HttpPut("{employeeId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult UpdateEmployee(int employeeId, Employee employee)
    {
        _employeeService.UpdateEmployee(employeeId, employee);
        return Ok(GetResponse(null));
    }

    [HttpPost()]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public IActionResult CreateEmployee(Employee employee)
    {
        int id = _employeeService.CreateEmployee(employee);
        return Ok(GetResponse(id));
    }

    private static ApiResponse GetResponse(object data)
    {
        return new ApiResponse
        {
            Data = data,
            Status = System.Net.HttpStatusCode.OK
        };
    }
}
