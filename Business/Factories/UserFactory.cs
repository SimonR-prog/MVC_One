using Data.Entities;
using Domain.Models;
using Domain.Models.Forms;

namespace Business.Factories;

public class UserFactory
{
    public static User Create(UserEntity entity)
    {
        if (entity == null) { return null!; }
        var user = new User()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email!,
            PhoneNumber = entity.PhoneNumber
        };
        return user;
    }

    public static UserEntity Create(SignUpFormData signUpFormData)
    {
        if (signUpFormData == null) { return null!; }
        var entity = new UserEntity()
        {
            FirstName = signUpFormData.FirstName,
            LastName = signUpFormData.LastName,
            Email = signUpFormData.Email,
        };
        return entity;
    }
}
