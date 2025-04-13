using Domain.Models.Forms;
using MVC_One.Models;

namespace MVC_One.Factories;

public class SignInFactory
{
    public static SignInFormData Create(LoginViewModel loginViewModel)
    {
        var formData = new SignInFormData()
        {
            Email = loginViewModel.Email,
            Password = loginViewModel.Password,
            IsPersistent = loginViewModel.RememberMe
        };
        return formData;
    }
}
