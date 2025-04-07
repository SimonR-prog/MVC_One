using Domain.Models;
using Domain.Models.ResponseHandlers;


namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse<IEnumerable<User>>> GetAllUsersAsync();
    }
}