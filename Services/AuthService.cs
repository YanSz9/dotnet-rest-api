namespace dotnetapi.Services;

using Azure;
using dotnetapi.DataContext;
using dotnetapi.Interfaces;
using dotnetapi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    public AuthService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ResponseViewModel<UserResponseViewModel>> Register(UserResponseViewModel userRegister)
    {
        ResponseViewModel<UserResponseViewModel> responseViewModel = new ResponseViewModel<UserResponseViewModel>();
        try
        {
            if (!VerifyUserAndEmail(userRegister))
            {
                responseViewModel.Data = null;
                responseViewModel.Sucess = false;
                responseViewModel.Message = "Email/Usuário already exists";
                return responseViewModel;
            }
        }
        catch (Exception ex)
        {

            responseViewModel.Data = null;
            responseViewModel.Message = ex.Message;
            responseViewModel.Sucess = false;
        }
        return responseViewModel;
    }
    public bool VerifyUserAndEmail(UserResponseViewModel userRegister)
    {
        var user = _context.Users.FirstOrDefault(userData => userData.Email == userRegister.Email || userData.User == userRegister.User);

        if (user != null) return false;
        return true;
    }
}