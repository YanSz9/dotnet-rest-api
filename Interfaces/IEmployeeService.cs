using dotnetapi.Models;

namespace dotnetapi.Interfaces;

public interface IEmployeeService
{
    Task<ResponseViewModel<List<EmployeeRequestViewModel>>> GetEmployees();
    Task<ResponseViewModel<List<EmployeeRequestViewModel>>> CreateEmployee(EmployeeRequestViewModel newEmployee);
    Task<ResponseViewModel<EmployeeRequestViewModel>> GetEmployeeById(int id);
    Task<ResponseViewModel<List<EmployeeRequestViewModel>>> UpdateEmployee(EmployeeRequestViewModel updatedEmployee);
    Task<ResponseViewModel<List<EmployeeRequestViewModel>>> DeleteEmployee(int id);
    Task<ResponseViewModel<List<EmployeeRequestViewModel>>> InactiveEmployee(int id);
}