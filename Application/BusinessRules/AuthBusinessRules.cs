using Core.Utilities.Security.Hashing;
using CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using Persistence.Abstract.IRepositories;

namespace Application.BusinessRules;

public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
    {
        User? user = await _userRepository.GetAsync(u=>u.Email==email);
        if (user != null) throw new BusinessException("Mail already exists");

    }
    
    public async Task<User> UserShouldExistForGivenMail(string email)
    {
        User? user = await _userRepository.GetAsync(u=>u.Email==email);
        if (user == null) throw new BusinessException("User not found");
        return user;
    }
    
    public async Task PasswordShouldMatchForGivenUser(User user,string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash!, user.PasswordSalt!))
        {
            throw new BusinessException("Password is wrong");
        }
    }
}