using dotnetapi.Models;

namespace dotnetapi.Interfaces;

public interface IAuthService
{
    Task<ResponseViewModel<UserResponseViewModel>> Register(UserResponseViewModel userRegister);
}