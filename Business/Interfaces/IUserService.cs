using Domain.Interfaces;
using Domain.Models;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<IResponseContent<IEnumerable<User?>>> GetAllUsersAsync();
    }
}