using Core.Utilities.Security.JWT;
using Domain.Entities;

namespace Application.DTOs.Responses;

public class UserLoggedInDto : RefreshedTokenDto
{
    public UserLoggedInDto(AccessToken accessToken, RefreshToken refreshToken) : base(accessToken, refreshToken)
    {
    }
}