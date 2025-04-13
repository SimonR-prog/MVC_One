using Domain.Models.Forms;
using Domain.Models.ResponseHandlers;

namespace Business.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> SignInAsync(SignInFormData formData);
        Task SignOutAsync();
        Task<AuthResponse> SignUpAsync(SignUpFormData formData);
    }
}