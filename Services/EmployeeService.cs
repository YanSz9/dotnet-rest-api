using dotnetapi.DataContext;
using dotnetapi.Interfaces;
using dotnetapi.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _context;
    public EmployeeService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ResponseViewModel<List<EmployeeRequestViewModel>>> CreateEmployee(EmployeeRequestViewModel newEmployee)
    {
        ResponseViewModel<List<EmployeeRequestViewModel>> responseViewModel = new ResponseViewModel<List<EmployeeRequestViewModel>>();

        try
        {
            if (newEmployee == null)
            {
                responseViewModel.Data = null;
                responseViewModel.Message = "Report data!";
                responseViewModel.Sucess = false;

                return responseViewModel;
            }

            _context.Add(newEmployee);
            await _context.SaveChangesAsync();

            responseViewModel.Data = _context.Employees.ToList();
        }
        catch (Exception ex)
        {

            responseViewModel.Message = ex.Message;
            responseViewModel.Sucess = false;
        }
        return responseViewModel;
    }

    public Task<ResponseViewModel<List<EmployeeRequestViewModel>>> DeleteEmployee(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseViewModel<EmployeeRequestViewModel>> GetEmployeeById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseViewModel<List<EmployeeRequestViewModel>>> GetEmployees()
    {
        ResponseViewModel<List<EmployeeRequestViewModel>> responseViewModel = new ResponseViewModel<List<EmployeeRequestViewModel>>();

        try
        {
            responseViewModel.Data = await _context.Employees.ToListAsync();
            if (responseViewModel.Data.Count == 0)
            {
                responseViewModel.Message = "No data found";
            }
        }
        catch (Exception ex)
        {
            responseViewModel.Message = ex.Message;
            responseViewModel.Sucess = false;
        }
        return responseViewModel;
    }

    public Task<ResponseViewModel<List<EmployeeRequestViewModel>>> InactiveEmployee(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseViewModel<List<EmployeeRequestViewModel>>> UpdateEmployee(EmployeeRequestViewModel updatedEmployee)
    {
        throw new NotImplementedException();
    }
}