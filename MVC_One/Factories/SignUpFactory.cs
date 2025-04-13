using Domain.Models.Forms;
using MVC_One.Models;

namespace MVC_One.Factories;

public class SignUpFactory
{
    public static SignUpFormData Create(RegisterViewModel registerModel)
    {
        var signUpFormData = new SignUpFormData()
        {
            Email = registerModel.Email,
            Password = registerModel.Password,
            FirstName = registerModel.FirstName,
            LastName = registerModel.LastName,
        };
        return signUpFormData;
    }
}
