using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Models;
using Domain.Models.ResponseHandlers;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserResponse<IEnumerable<User>>> GetAllUsersAsync()
    {
        var entities = await _userRepository.GetAllAsync();
        if (entities.Content == null)
        {
            return new UserResponse<IEnumerable<User>>()
            {
                Success = false,
                StatusCode = 404,
                Content = []
            };
        }
        var users = entities.Content.Select(UserFactory.Create);
        if (users.IsNullOrEmpty()) 
        {
            return new UserResponse<IEnumerable<User>>()
            {
                Success = true,
                StatusCode = 204,
                Content = []
            };
        }
        return new UserResponse<IEnumerable<User>>()
        {
            Success = true,
            StatusCode = 200,
            Content = users
        };
    }
}



//Check more..