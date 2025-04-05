using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Business.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;


    public async Task<IResponseContent<IEnumerable<Client?>>> GetAllClientAsync()
    {
        var entities = await _clientRepository.GetAllAsync();

        if (entities.Content == null)
        {
            return Response<IEnumerable<Client?>>.NotFound(new List<Client>(), "There are no clients.");
        }
        var clients = entities.Content.Select(ClientFactory.Create);
        return Response<IEnumerable<Client?>>.Ok(clients);
    }


}
