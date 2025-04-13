using Domain.Models;
using Domain.Models.Forms;
using Domain.Models.ResponseHandlers;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> AddUserAsync(SignUpFormData signUpFormData);
        Task<UserResponse<IEnumerable<User>>> GetAllUsersAsync();
        Task<UserResponse<User>> GetUserByIdAsync(string id);
        Task<UserResponse> UserExistingByEmailAsync(string email);
    }
}