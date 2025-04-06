using Business.Interfaces;
using Domain.Models.Forms;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Domain.Models.ResponseHandlers;

namespace Business.Services;

public class AuthService(IUserService userService, SignInManager<UserEntity> signInManager)
{
    private readonly IUserService _userService = userService;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    public async Task<AuthResponse> SignInAsync(SignInFormData formData)
    {
        if (formData == null)
            return new AuthResponse();

        var result = await _signInManager.PasswordSignInAsync(formData.Email, formData.Password, formData.IsPersistent, false);
        return result;
    }

    public async Task<AuthResponse> SignUpAsync(SignUpFormData formData)
    {
        if (formData == null)
            return 
    }
}