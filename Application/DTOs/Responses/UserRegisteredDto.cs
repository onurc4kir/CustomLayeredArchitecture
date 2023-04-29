using Core.Utilities.Security.JWT;
using Domain.Entities;

namespace Application.DTOs.Responses;

public class UserRegisteredDto : RefreshedTokenDto
{
    public UserRegisteredDto(AccessToken accessToken, RefreshToken refreshToken) : base(accessToken, refreshToken)
    {
    }
}