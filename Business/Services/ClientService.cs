using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Models;
using Domain.Models.ResponseHandlers;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;


    public async Task<ClientResponse<IEnumerable<Client?>>> GetAllClientAsync()
    {
        try
        {
            var clientEntities = await _clientRepository.GetAllAsync();
            if (clientEntities.Content.IsNullOrEmpty())
            {
                return new ClientResponse<IEnumerable<Client?>>()
                {
                    Success = false,
                    StatusCode = 404,
                    ErrorMessage = "The list is null or empty.",
                    Content = []
                };
            }

            var clients = clientEntities.Content.Select(ClientFactory.Create);
            return new ClientResponse<IEnumerable<Client?>>()
            {
                Success = true,
                StatusCode = 200,
                Content = clients
            };
        }
        catch (Exception ex) 
        {
            return new ClientResponse<IEnumerable<Client?>>()
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = $"{ex.Message}",
                Content = []
            };
        }
    }


}
