using System.Security.Claims;
using Application.BusinessRules;
using Application.DTOs;
using Application.DTOs.Requests;
using Application.Services.IServices;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Abstract.IRepositories;
using Persistence.Abstract.Pagination;

namespace Application.Services;

public class AuthManager : IAuthService
{
    private readonly ITokenService _tokenService;
    
    private readonly IUserRepository _userRepository;
    private  readonly IUserOperationClaimRepository _userOperationClaimRepository;
    
    private readonly AuthBusinessRules _authBusinessRules;
    
    public AuthManager(ITokenService tokenService, IUserRepository userRepository,AuthBusinessRules authBusinessRules, IUserOperationClaimRepository userOperationClaimRepository)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
        _authBusinessRules = authBusinessRules;
        _userOperationClaimRepository = userOperationClaimRepository;
    }
    
    
    public async Task<IDataResult<User>> Register(UserRegisterDto userRegisterDto)
    {
        await _authBusinessRules.EmailCanNotBeDuplicatedWhenRegistered(email:userRegisterDto.Email);
        
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
        
        var user = new User
        {
            Email = userRegisterDto.Email,
            FirstName = userRegisterDto.FirstName,
            LastName = userRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
        };
        await _userRepository.AddAsync(user);
        return new DataResult<User>(user, true, "User is registered");
    }

    public async Task<IDataResult<User>> Login(UserLoginDto userLoginDto)
    {
        var user = await _authBusinessRules.UserShouldExistForGivenMail(email:userLoginDto.Email);
        
        await _authBusinessRules.PasswordShouldMatchForGivenUser(user:user,password:userLoginDto.Password);
        
        return new DataResult<User>(user, true, "Login is successful");
    }

    public async Task<IResult> UserExists(string email)
    {
        var data = await _userRepository.GetAsync(p => p.Email == email);
    return data != null ? new DataResult<User>(
        data, true, "User with that mail is exists") : new ErrorResult();
    }

    
    public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
    {
        IPaginate<UserOperationClaim> userOperationClaims =
            await _userOperationClaimRepository.GetListAsync(u => u.UserId == user.Id,
                include: u =>
                    u.Include(u => u.OperationClaim)
            );
        List<OperationClaim> operationClaims =
            userOperationClaims.Items.Select(u => new OperationClaim
                { Id = u.OperationClaim.Id, Name = u.OperationClaim.Name }).ToList();

        AccessToken accessToken = _tokenService.CreateToken(user, operationClaims);
        return new SuccessDataResult<AccessToken>(accessToken);
    }

    public async Task<IDataResult<RefreshToken>> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken =  _tokenService.CreateRefreshToken(user, ipAddress);
        return new SuccessDataResult<RefreshToken>(refreshToken);
    }
}