using Application.DTOs;
using Application.DTOs.Requests;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Domain.Entities;

namespace Application.Services.IServices;

public interface IAuthService
{
    Task<IDataResult<User>> Register(UserRegisterDto userRegisterDto);
    Task<IDataResult<User>> Login(UserLoginDto userLoginDto);
    Task<IResult> UserExists(string email);
    Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    Task<IDataResult<RefreshToken>> CreateRefreshToken(User user, string ipAddress);

}