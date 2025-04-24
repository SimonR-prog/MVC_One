using Business.Interfaces;
using Domain.Models.Forms;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Domain.Models.ResponseHandlers;
using Business.Factories;

namespace Business.Services;

public class AuthService(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, IUserService userService) : IAuthService
{
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly IUserService _userService = userService;

    public async Task<AuthResponse> SignInAsync(SignInFormData formData)
    {
        try
        {
            if (formData == null)
                return new AuthResponse()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "The login form data is null."
                };

            var result = await _signInManager.PasswordSignInAsync(formData.Email, formData.Password, formData.IsPersistent, false);
            if (!result.Succeeded)
            {
                return new AuthResponse()
                {
                    Success = false,
                    StatusCode = 400,
                    ErrorMessage = "Something went wrong when loggin in."
                };
            }
            return new AuthResponse()
            {
                Success = true,
                StatusCode = 200,
            };

        }
        catch (Exception ex)
        {
            return new AuthResponse()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}"
            };
        }
    }

    public async Task<AuthResponse> SignUpAsync(SignUpFormData formData)
    {
        try
        {
            if (formData == null)
                return new AuthResponse()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "The sign up form data is null."
                };

            var userEntity = UserFactory.Create(formData);
            userEntity.UserName = userEntity.Email;
            var createResult = await _userManager.CreateAsync(userEntity, formData.Password);

            if (!createResult.Succeeded)
            {
                return new AuthResponse()
                {
                    Success = false,
                    StatusCode = 400,
                    ErrorMessage = "Could not create user."
                };
            }

            return new AuthResponse()
            {
                Success = true,
                StatusCode = 200,
            };
        }
        catch (Exception ex)
        {
            return new AuthResponse()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
            };
        }
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}