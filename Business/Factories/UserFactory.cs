using Data.Entities;
using Domain.Models;

namespace Business.Factories;

public class UserFactory
{
    public static User Create(UserEntity entity)
    {
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
}
