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
    private readonly IPasswordService _passwordService;
    public AuthService(ApplicationDbContext context, IPasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
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
                responseViewModel.Message = "Email/User already exists";
                return responseViewModel;
            }
            _passwordService.CreateHashPassword(userRegister.Password, out byte[] passwordHash, out byte[] passwordSalt);

            UserViewModel user = new UserViewModel()
            {
                User = userRegister.User,
                Email = userRegister.Email,
                Role = userRegister.Role,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _context.Add(user);
            await _context.SaveChangesAsync();

            responseViewModel.Message = "User created successfully!";
        }

        catch (Exception ex)
        {

            responseViewModel.Data = null;
            responseViewModel.Message = ex.Message;
            responseViewModel.Sucess = false;
        }
        return responseViewModel;
    }

    public async Task<ResponseViewModel<string>> Login(UserLoginViewModel userLogin)
    {
        ResponseViewModel<string> responseViewModel = new ResponseViewModel<string>();
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(userData => userData.Email == userLogin.Email);

            if (user == null)
            {
                responseViewModel.Message = "Invalid Credentials!";
                responseViewModel.Sucess = false;
                return responseViewModel;
            }

            if (!_passwordService.VerifyHashPassword(userLogin.Password, user.PasswordHash, user.PasswordSalt))
            {
                responseViewModel.Message = "Invalid Credentials!";
                responseViewModel.Sucess = false;
                return responseViewModel;
            }
            var token = _passwordService.CreateToken(user);

            responseViewModel.Data = token;
            responseViewModel.Message = "User successfully logged in!";


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