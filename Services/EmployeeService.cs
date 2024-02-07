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

    public async Task<ResponseViewModel<EmployeeRequestViewModel>> GetEmployeeById(int id)
    {
        ResponseViewModel<EmployeeRequestViewModel> responseViewModel = new ResponseViewModel<EmployeeRequestViewModel>();

        try
        {
            EmployeeRequestViewModel employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                responseViewModel.Data = null;
                responseViewModel.Message = "User not found";
                responseViewModel.Sucess = false;
            }
            responseViewModel.Data = employee;

        }
        catch (Exception ex)
        {
            responseViewModel.Message = ex.Message;
            responseViewModel.Sucess = false;
        }
        return responseViewModel;
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

    public async Task<ResponseViewModel<List<EmployeeRequestViewModel>>> InactiveEmployee(int id)
    {
        ResponseViewModel<List<EmployeeRequestViewModel>> responseViewModel = new ResponseViewModel<List<EmployeeRequestViewModel>>();

        try
        {
            EmployeeRequestViewModel employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);

            if (employee == null)
            {
                responseViewModel.Data = null;
                responseViewModel.Message = "User Not Found";
                responseViewModel.Sucess = false;
            }
            employee.Active = false;
            employee.UpdatedAt = DateTime.Now.ToLocalTime();

            _context.Employees.Update(employee);
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

    public async Task<ResponseViewModel<List<EmployeeRequestViewModel>>> UpdateEmployee(EmployeeRequestViewModel updatedEmployee)
    {
        ResponseViewModel<List<EmployeeRequestViewModel>> responseViewModel = new ResponseViewModel<List<EmployeeRequestViewModel>>();
        try
        {
            EmployeeRequestViewModel employee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == updatedEmployee.Id);

            if (employee == null)
            {
                responseViewModel.Data = null;
                responseViewModel.Message = "User Not Found";
                responseViewModel.Sucess = false;
            }

            employee.UpdatedAt = DateTime.Now.ToLocalTime();

            _context.Employees.Update(updatedEmployee);
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
}