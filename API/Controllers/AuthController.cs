

using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.Services.IServices;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AuthController : BaseController
{
    private readonly IAuthService _authService;
    
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userForLoginDto)
    {
        IDataResult<User> userResult = await _authService.Login(userForLoginDto);
        if (!userResult.Success) return BadRequest(userResult.Message);

        IDataResult<AccessToken> accessTokenResult = await _authService.CreateAccessToken(userResult.Data);
        if (!accessTokenResult.Success) return BadRequest(accessTokenResult.Message);
        
        IDataResult<RefreshToken> refreshTokenResult = await _authService.CreateRefreshToken(userResult.Data,ipAddress:GetIpAddress() ?? "null");

        SetRefreshTokenToCookie(refreshTokenResult.Data);
        
        return Ok(new UserLoggedInDto(
            accessToken: accessTokenResult.Data,
            refreshToken: refreshTokenResult.Data
        ));
    }
    
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto userForRegisterDto)
    {


        IDataResult<User> userResult = await _authService.Register(userForRegisterDto);
        if (!userResult.Success) return BadRequest(userResult.Message);

        IDataResult<AccessToken> accessTokenResult = await _authService.CreateAccessToken(userResult.Data);
        if (!accessTokenResult.Success) return BadRequest(accessTokenResult.Message);
        
        IDataResult<RefreshToken> refreshTokenResult = await _authService.CreateRefreshToken(userResult.Data,ipAddress:GetIpAddress() ?? "null");

        SetRefreshTokenToCookie(refreshTokenResult.Data);
        

        return Created("",new UserRegisteredDto(
                accessToken: accessTokenResult.Data,
                refreshToken: refreshTokenResult.Data
            ));
    }

    private void SetRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true ,Expires = DateTime.Now.AddDays(7)};
        Response.Cookies.Append("refreshToken",refreshToken.Token, cookieOptions);
    }

}