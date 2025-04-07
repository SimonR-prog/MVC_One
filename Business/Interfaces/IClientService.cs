using Domain.Models;
using Domain.Models.ResponseHandlers;

namespace Business.Interfaces
{
    public interface IClientService
    {
        Task<ClientResponse<IEnumerable<Client?>>> GetAllClientAsync();
    }
}