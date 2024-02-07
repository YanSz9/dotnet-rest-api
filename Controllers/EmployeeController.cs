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
    [HttpGet("get-all-user")]
    public async Task<ActionResult<ResponseViewModel<List<EmployeeRequestViewModel>>>> GetEmployees()
    {
        return Ok(await _employeeService.GetEmployees());
    }

    [HttpGet("get-single-user/{id}")]
    public async Task<ActionResult<ResponseViewModel<EmployeeRequestViewModel>>> GetEmployeeById(int id)
    {
        ResponseViewModel<EmployeeRequestViewModel> responseViewModel = await _employeeService.GetEmployeeById(id);

        return Ok(responseViewModel);
    }
    [HttpPost("create-user")]
    public async Task<ActionResult<ResponseViewModel<List<EmployeeRequestViewModel>>>> CreateEmployee(EmployeeRequestViewModel newEmployee)
    {
        return Ok(await _employeeService.CreateEmployee(newEmployee));
    }
    [HttpPut("update-employee")]
    public async Task<ActionResult<ResponseViewModel<List<EmployeeRequestViewModel>>>> UpdateEmployee(EmployeeRequestViewModel updatedEmployee)
    {
        ResponseViewModel<List<EmployeeRequestViewModel>> responseViewModel = await _employeeService.UpdateEmployee(updatedEmployee);

        return Ok(responseViewModel);
    }

    [HttpPut("inactive-employee")]
    public async Task<ActionResult<ResponseViewModel<List<EmployeeRequestViewModel>>>> InactiveEmployee(int id)
    {
        ResponseViewModel<List<EmployeeRequestViewModel>> responseViewModel = await _employeeService.InactiveEmployee(id);
        return Ok(responseViewModel);
    }
    [HttpDelete("delete-employee")]
    public async Task<ActionResult<ResponseViewModel<List<EmployeeRequestViewModel>>>> DeleteEmployee(int id)
    {
        ResponseViewModel<List<EmployeeRequestViewModel>> responseViewModel = await _employeeService.DeleteEmployee(id);
        return Ok(responseViewModel);
    }


}