
using Core.Utilities.Security.JWT;
using Domain.Entities;

namespace Application.DTOs.Responses
{
    public class RefreshedTokenDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
        
        public RefreshedTokenDto(AccessToken accessToken, RefreshToken refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}