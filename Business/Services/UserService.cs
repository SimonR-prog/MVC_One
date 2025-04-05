using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Business.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<IResponseContent<IEnumerable<User?>>> GetAllUsersAsync()
    {
        var entities = await _userRepository.GetAllAsync();

        if (entities.Content == null)
        {
            return Response<IEnumerable<User?>>.NotFound(new List<User>(), "There are no users.");
        }

        var users = entities.Content.Select(UserFactory.Create);
        return Response<IEnumerable<User?>>.Ok(users);
    }
}



//Check more..