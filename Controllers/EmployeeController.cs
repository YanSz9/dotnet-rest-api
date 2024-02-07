using dotnetapi.Interfaces;
using dotnetapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    [HttpGet]
    public async Task<ActionResult<ResponseViewModel<List<EmployeeRequestViewModel>>>> GetEmployees()
    {
        return Ok(await _employeeService.GetEmployees());
    }
}