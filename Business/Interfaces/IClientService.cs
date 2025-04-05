using Domain.Interfaces;
using Domain.Models;

namespace Business.Interfaces
{
    public interface IClientService
    {
        Task<IResponseContent<IEnumerable<Client?>>> GetAllClientAsync();
    }
}