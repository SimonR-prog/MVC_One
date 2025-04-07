using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Models;
using Domain.Models.ResponseHandlers;

namespace Business.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;


    public async Task<ClientResponse<IEnumerable<Client?>>> GetAllClientAsync()
    {
        var clientEntities = await _clientRepository.GetAllAsync();

        if (clientEntities.Content == null)
        {
            
        }
        var clients = clientEntities.Content.Select(ClientFactory.Create);
        
    }


}
