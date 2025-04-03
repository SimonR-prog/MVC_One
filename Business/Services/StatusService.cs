using Business.Factories;
using Data.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Business.Services;

public class StatusService(IStatusRepository statusRepository)
{
    private readonly IStatusRepository _statusRepository = statusRepository;


    public async Task<IResponseContent<IEnumerable<Status?>>> GetAllStatusAsync()
    {
        var entities = await _statusRepository.GetAllAsync();

        if (entities.Content == null)
        {
            return Response<IEnumerable<Status?>>.NotFound(new List<Status>(), "There are no statuses.");
        }

        var statuses = entities.Content.Select(StatusFactory.Create);
        return Response<IEnumerable<Status?>>.Ok(statuses);
    }



}
