using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Models;
using Domain.Models.Forms;
using Domain.Models.ResponseHandlers;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserResponse> AddUserAsync(SignUpFormData signUpFormData)
    {
        try
        {
            if (signUpFormData == null)
            {
                return new UserResponse()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "Invalid sign up data."
                };
            }

            var entity = UserFactory.Create(signUpFormData);
            if (entity == null)
            {
                return new UserResponse()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "Invalid entity."
                };
            }

            var result = await _userRepository.CreateAsync(entity);
            if (!result.Success)
            {
                return new UserResponse()
                {
                    Success = false,
                    StatusCode = 400,
                    ErrorMessage = result.ErrorMessage
                };
            }

            return new UserResponse()
            {
                Success = true,
                StatusCode = 200
            };
        }
        catch (Exception ex)
        {
            return new UserResponse()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}"
            };
        }
    }

    public async Task<UserResponse<IEnumerable<User>>> GetAllUsersAsync()
    {
        try
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
        catch (Exception ex)
        {
            return new UserResponse<IEnumerable<User>>()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
            };
        }
    }

    public async Task<UserResponse<User>> GetUserByIdAsync(string id)
    {
        try
        {
            if (id.IsNullOrEmpty())
            {
                return new UserResponse<User>()
                {
                    Success = false,
                    StatusCode = 400,
                    ErrorMessage = "Id is null."
                };
            }

            var existsResult = await _userRepository.ExistsAsync(x => x.Id == id);
            if (!existsResult.Success)
            {
                return new UserResponse<User>()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "User with this id does not exist."
                };
            }

            var result = await _userRepository.GetAsync(x => x.Id == id);
            if (result.Content == null)
            {
                return new UserResponse<User>()
                {
                    Success = false,
                    StatusCode = 400,
                    ErrorMessage = "Id is null."
                };
            }

            return new UserResponse<User>()
            {
                Success = true,
                StatusCode = 200,
                Content = UserFactory.Create(result.Content)
            };
        }
        catch (Exception ex)
        {
            return new UserResponse<User>()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
            };
        }
    }

    public async Task<UserResponse> UserExistingByEmailAsync(string email)
    {
        try
        {
            if (email.IsNullOrEmpty())
            {
                return new UserResponse()
                {
                    Success = false,
                    StatusCode = 500,
                    ErrorMessage = "Email is null."
                };
            }

            var existsResult = await _userRepository.ExistsAsync(x => x.Email == email);
            if (!existsResult.Success)
            {
                return new UserResponse()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "User not found."
                };
            }

            return new UserResponse()
            {
                Success = true,
                StatusCode = 200,
            };
        }
        catch (Exception ex)
        {
            return new UserResponse()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
            };
        }
    }
}