using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Models;
using Domain.Models.ResponseHandlers;

namespace Business.Services;

public class StatusService(IStatusRepository statusRepository) : IStatusService
{
    private readonly IStatusRepository _statusRepository = statusRepository;


    public async Task<StatusResponse<IEnumerable<Status?>>> GetAllStatusAsync()
    {
        var statusEntities = await _statusRepository.GetAllAsync();

        if (statusEntities.Content == null)
        {
            
        }

        var statuses = statusEntities.Content.Select(StatusFactory.Create);
        
    }



}
